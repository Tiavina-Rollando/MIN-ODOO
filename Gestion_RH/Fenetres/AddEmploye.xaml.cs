using System;
using System.Collections.Generic;
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
using Gestion_RH.Pages;
using Microsoft.Win32;

namespace Gestion_RH.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour AddEmploye.xaml
    /// </summary>
    public partial class AddEmploye : Window, INotifyPropertyChanged
    {
        private Accueil _accueilPage;

        public AddEmploye(Accueil accueilPage)
        {
            InitializeComponent();
            _accueilPage = accueilPage;
            using (var dbContext = new ApplicationDbContext())
            {
                var paysListe = dbContext.Nations.ToList();
                PaysComboBox.ItemsSource = paysListe;
                var roleListe = dbContext.Roles.ToList();
                RolesComboBox.ItemsSource = roleListe;
                var posteListe = dbContext.Postes.ToList();
                PostesComboBox.ItemsSource = posteListe;
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void AddCV_Click(int id)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Tous les fichiers (*.*)|*.*",
                Title = "Sélectionner un fichier"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                byte[] fileBytes = File.ReadAllBytes(openFileDialog.FileName);
                Cv CV = new Cv
                    {
                        NomFichier = System.IO.Path.GetFileName(openFileDialog.FileName),
                        Fichier = fileBytes,
                        EmployeId = id
                    };
            
                if (!string.IsNullOrEmpty(CV.NomFichier))
                {
                    using var dbContext = new ApplicationDbContext();

                    dbContext.Cvs.Add(CV);
                    dbContext.SaveChanges();
                    MessageBox.Show("Curriculum vitae bien ajouté.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void Inserer_Click(object sender, RoutedEventArgs e)
        {
            byte[] photoBytes = File.ReadAllBytes("../../../Assets/pdpVide.jpg");

            Employe novice = new Employe()
            {
                Nom = NomEmployeTextBox.Text.Trim(),
                Prenom = PrenomEmployeTextBox.Text.Trim(),
                Email = EmailEmployeTextBox.Text.Trim(),
                Adresse = AdresseEmployeTextBox.Text.Trim(),
                Tel = TelEmployeTextBox.Text.Trim(),
                Photo = photoBytes,
                Sexe = ((ComboBoxItem)SexeEmployeComboBox.SelectedItem).Content.ToString() == "Homme",
                IdNation = (int)PaysComboBox.SelectedValue,
                IdPoste = (int)PostesComboBox.SelectedValue,
                IdRole = (int)RolesComboBox.SelectedValue,
                DateIntegration = DateIntegrationEmployePicker.SelectedDate ?? DateTime.Now,
                DateNaissance = DateNaissanceEmployePicker.SelectedDate
            };

            if (!string.IsNullOrEmpty(novice.Nom))
            {
                using var dbContext = new ApplicationDbContext();

                dbContext.Employes.Add(novice);
                dbContext.SaveChanges();
                MessageBox.Show("Employé bien enregistré.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                _accueilPage.Rafraichir();
                this.Close();
                var resultat = MessageBox.Show("Voulez-vous ajouter un CV pour cet employé ?", "Ajouter CV", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resultat == MessageBoxResult.Yes)
                {
                    AddCV_Click(novice.Id);
                }


            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
