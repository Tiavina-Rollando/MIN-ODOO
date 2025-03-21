using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Microsoft.Win32;

namespace Gestion_RH.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour UpdateTache.xaml
    /// </summary>
    public partial class UpdateTache : Window, INotifyPropertyChanged
    {
        private Tache tache;
        public ObservableCollection<string> Consignes { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<Support> SupportList { get; set; } = new ObservableCollection<Support>();

        public void ChargerSupports()
        {
            foreach (var item in tache.Supports)
            {
                SupportList.Add(item);
            }
        }
        public UpdateTache(Tache task)
        {
            InitializeComponent();

            DataContext = this;
            tache = task;
            ChargerSupports();
            NomTacheTextBox.Text = tache.Nom;
            DateExpeditionPicker.SelectedDate = tache.DateExpedition;
            DateDeadlinePicker.SelectedDate = tache.Deadline;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private void SaveUpdateTask_Click(object sender, RoutedEventArgs e)
        {
            if (tache is Tache taskSel)
            {
                using var dbContext = new ApplicationDbContext();
                var tache = dbContext.Taches.Find(taskSel.Id);

                if (tache != null)
                {
                    tache.Nom = NomTacheTextBox.Text.Trim();
                    tache.DateExpedition = DateExpeditionPicker.SelectedDate ?? DateTime.Now;
                    tache.Deadline = (DateTime)DateDeadlinePicker.SelectedDate;

                    MessageBoxResult result = MessageBox.Show(
                            $"Valider les mises à jour sur {tache?.Nom ?? ""}?",
                            "Confirmation",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var support in SupportList)
                        {
                            tache.Supports.Add(new Support { Fichier = support.Fichier, NomFichier = support.NomFichier });
                        }
                        dbContext.SaveChanges();
                        MessageBox.Show("Tâche modifiée avec succès.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }

            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une tâche à modifier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Supprimer ?");
            if (sender is Button button && button.Tag is string tag)
            {
                var parts = tag.Split('|');
                if (parts.Length != 2 || !int.TryParse(parts[1], out int id))
                {
                    MessageBox.Show("Erreur de format dans le Tag");
                    return;
                }
                string classe = parts[0];

                // Demande de confirmation
                MessageBoxResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer ceci?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using var dbContext = new ApplicationDbContext();

                    var support = dbContext.Supports.Find(id);
                    if (support != null)
                    {
                        dbContext.Supports.Remove(support);
                        dbContext.SaveChanges();
                        MessageBox.Show("Support supprimé avec succès !");

                        this.InitializeComponent();
                    }
                }
            }
        }
    }
}
