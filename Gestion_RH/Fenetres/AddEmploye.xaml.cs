using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Gestion_RH.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour AddEmploye.xaml
    /// </summary>
    public partial class AddEmploye : Window, INotifyPropertyChanged
    {
        public AddEmploye()
        {
            InitializeComponent();
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

        private void Inserer_Click(object sender, RoutedEventArgs e)
        {
            Employe novice = new Employe()
            {
                Nom = NomEmployeTextBox.Text.Trim(),
                Prenom = PrenomEmployeTextBox.Text.Trim(),
                Email = EmailEmployeTextBox.Text.Trim(),
                Adresse = AdresseEmployeTextBox.Text.Trim(),
                Tel = TelEmployeTextBox.Text.Trim(),
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

                NomEmployeTextBox.Clear();
                PrenomEmployeTextBox.Clear();

            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
