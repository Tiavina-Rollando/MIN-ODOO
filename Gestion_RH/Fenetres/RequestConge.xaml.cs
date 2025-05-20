using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour RequestConge.xaml
    /// </summary>
    public partial class RequestConge : Window
    {
        private Employe user = new Employe();
        public RequestConge(Employe sujet)
        {
            InitializeComponent();
            user = sujet;
        }
        private void EtapeMotif_Suivant(object sender, RoutedEventArgs e)
        {
            if (MotifComboBox.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un motif.");
                return;
            }

            EtapeMotif.Visibility = Visibility.Collapsed;
            EtapeDebut.Visibility = Visibility.Visible;
        }

        private void EtapeDebut_Suivant(object sender, RoutedEventArgs e)
        {
            if (DateDebutPicker.SelectedDate == null)
            {
                MessageBox.Show("Veuillez sélectionner une date de début.");
                return;
            }

            EtapeDebut.Visibility = Visibility.Collapsed;
            EtapeFin.Visibility = Visibility.Visible;
        }

        private void EnvoyerDemande(object sender, RoutedEventArgs e)
        {
            if (DateFinPicker.SelectedDate == null)
            {
                MessageBox.Show("Veuillez sélectionner une date de fin.");
                return;
            }
            string motif = ((ComboBoxItem)MotifComboBox.SelectedItem).Content.ToString();
            DateTime dateDebut = DateDebutPicker.SelectedDate.Value;
            DateTime dateFin = DateFinPicker.SelectedDate.Value;
            if (dateFin < dateDebut)
            {
                MessageBox.Show("La date de fin ne peut pas être avant la date de début.");
                return;
            }
            DemandeConge demande = new DemandeConge();
            demande.Motif = motif;
            demande.Debut = dateDebut;
            demande.Fin = dateFin;
            demande.EmployeId = user.Id;
            demande.Statut = 0; 
            demande.Envoye = DateTime.Now;
            using var db = new ApplicationDbContext();
            db.DemandesConge.Add(demande);
            db.SaveChanges();
            // Ici, tu peux enregistrer la demande de congé dans ta base
            MessageBox.Show($"Demande envoyée :\nMotif: {motif}\nDu {dateDebut:dd/MM/yyyy} au {dateFin:dd/MM/yyyy}");
            this.Close(); // Ferme la fenêtre après envoi
        }

    }
}
