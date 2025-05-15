using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Gestion_RH.Classes;
using Gestion_RH.Pages;
using Microsoft.Win32;

namespace Gestion_RH.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        private Tache task { get; set; }
        public ObservableCollection<string> Consignes { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<Support> SupportList { get; set; } = new ObservableCollection<Support>();

        private Accueil _accueilPage;

        public AddTask(Accueil accueilPage)
        {
            InitializeComponent();
            _accueilPage = accueilPage;
            DataContext = this;
        }
        private void Inserer_Click(object sender, RoutedEventArgs e)
        {
            task = new Tache()
            {
                Nom = NomTacheTextBox.Text.Trim(),
                DateExpedition = DateExpeditionPicker.SelectedDate ?? DateTime.Now,
                Deadline = DateDeadlinePicker.SelectedDate ?? DateTime.Now
            };

            if (!string.IsNullOrEmpty(task.Nom))
            {
                foreach ( var consigneText in Consignes)
                {
                    task.Consignes.Add(new Consigne { Designation = consigneText });
                }
                foreach ( var support in SupportList)
                {
                    task.Supports.Add(new Support { Fichier = support.Fichier, NomFichier = support.NomFichier });
                }

                using var dbContext = new ApplicationDbContext();
                dbContext.Taches.Add(task);
                dbContext.SaveChanges();
                MessageBox.Show("Tâche bien enregistrée.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                _accueilPage.Rafraichir();
                this.Close();
            }
            else
            {
                MessageBox.Show("Veuillez entrer un objet valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        
        private void AddSupport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Tous les fichiers (*.*)|*.*",
                Title = "Sélectionner un fichier"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                byte[] fileBytes = File.ReadAllBytes(openFileDialog.FileName);
                SupportList.Add(new Support
                {
                    NomFichier = System.IO.Path.GetFileName(openFileDialog.FileName),
                    Fichier = fileBytes
                });
            }
        }


        private void AddConsigne_Click(object sender, RoutedEventArgs e)
        {
            AddConsigne addWindow = new AddConsigne(Consignes);
            addWindow.ShowDialog();

        }
    }
}
