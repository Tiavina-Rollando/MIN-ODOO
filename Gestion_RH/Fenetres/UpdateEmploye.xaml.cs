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
using Gestion_RH.Pages;

namespace Gestion_RH.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour UpdateEmploye.xaml
    /// </summary>
    public partial class UpdateEmploye : Window, INotifyPropertyChanged
    {
        private Employe employe;
        private Info _infoPage;
        public UpdateEmploye(Info InfoPage,Employe emp)
        {
            InitializeComponent();
            employe = emp;
            using (var dbContext = new ApplicationDbContext())
            {
                var paysListe = dbContext.Nations.ToList();
                PaysUpdateComboBox.ItemsSource = paysListe;
                var posteListe = dbContext.Postes.ToList();
                PostesUpdateComboBox.ItemsSource = posteListe;
            }

            NomTextUpdateBox.Text = employe.Nom;
            PrenomTextUpdateBox.Text = employe.Prenom;
            EmailTextUpdateBox.Text = employe.Email;
            AdresseTextUpdateBox.Text = employe.Adresse;
            TelTextUpdateBox.Text = employe.Tel;
            DateIntegrationUpdatePicker.SelectedDate = employe.DateIntegration;
            DateNaissanceUpdatePicker.SelectedDate = employe.DateNaissance;
            _infoPage = InfoPage;

            DataContext = this;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SaveUpdateEmploye_Click(object sender, RoutedEventArgs e)
        {
            if (employe is Employe employeSelectionne)
            {
                using var dbContext = new ApplicationDbContext();
                var employe = dbContext.Employes.Find(employeSelectionne.Id);

                if (employe != null)
                {
                    employe.Nom = NomTextUpdateBox.Text.Trim();
                    employe.Prenom = PrenomTextUpdateBox.Text.Trim();
                    employe.Email = EmailTextUpdateBox.Text.Trim();
                    employe.Adresse = AdresseTextUpdateBox.Text.Trim();
                    employe.Tel = TelTextUpdateBox.Text.Trim();
                    employe.Sexe = ((ComboBoxItem)SexeUpdateComboBox.SelectedItem).Content.ToString() == "Homme";
                    employe.IdNation = (int)PaysUpdateComboBox.SelectedValue;
                    employe.IdPoste = (int)PostesUpdateComboBox.SelectedValue;
                    employe.DateIntegration = DateIntegrationUpdatePicker.SelectedDate ?? DateTime.Now;
                    employe.DateNaissance = DateNaissanceUpdatePicker.SelectedDate;

                    MessageBoxResult result = MessageBox.Show(
                            $"Valider les mises à jour sur {employe?.Nom ?? ""} {employe?.Prenom ?? ""}?",
                            "Confirmation",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        dbContext.SaveChanges();
                        MessageBox.Show("Employé modifié avec succès.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                        _infoPage.Rafraichir();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un employé à modifier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
