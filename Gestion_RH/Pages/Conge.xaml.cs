using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gestion_RH.Classes;
using Microsoft.EntityFrameworkCore;

namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour Conge.xaml
    /// </summary>
    public partial class Conge : Page
    {
        
        public Conge()
        {
            InitializeComponent();
            DataContext = this;
            Afficher();
            ((Storyboard)this.Resources["HideNotificationPanel"]).Completed += (s, e) =>
            {
                NotificationPanel.Visibility = Visibility.Collapsed;
            };
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Accueil()); // Naviguer vers la page d'accueil
        }
        private void Calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (calendar?.SelectedDate != null)
            {
                MessageBox.Show(calendar.SelectedDate.Value.ToShortDateString());
            }
        }
        private void BtnNotifications_Click(object sender, RoutedEventArgs e)
        {
            NotificationPanel.Visibility = Visibility.Visible;
            var storyboard = (Storyboard)this.Resources["ShowNotificationPanel"];
            storyboard.Begin();

        }
        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            var hide = (Storyboard)this.Resources["HideNotificationPanel"];
            hide.Begin();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Supprimer ?");
            if (sender is Button button && button.Tag is int tag)
            {
                int Id = tag;

                // Demande de confirmation
                MessageBoxResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer ceci?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using var dbContext = new ApplicationDbContext();

                    var conge = dbContext.Conges.Find(Id);
                    if (conge != null)
                    {
                        dbContext.Conges.Remove(conge);
                        dbContext.SaveChanges();
                        MessageBox.Show("Congé supprimé avec succès !");
                    }
                            
                };
                Afficher();
            }
        }
        public void Afficher()
        {
            using var dbContext = new ApplicationDbContext();

            var conges = dbContext.Conges
                .Include(p => p.Employe)
                .Select(p => new
                {
                    p.Motif,
                    p.Debut,
                    p.Fin,
                    Statut = DateTime.Now >= p.Debut && DateTime.Now <= p.Fin
                        ? "En cours"
                        : (DateTime.Now < p.Debut
                            ? "À venir"
                            : "Achevé"),
                    p.NomEmploye
                })
                .ToList();

            CongesDataGrid.ItemsSource = conges;
        }

        private void calConge_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (calConge.SelectedDate.HasValue)
            {
                DateTime selectedDate = calConge.SelectedDate.Value.Date;
                ChargerCongesParDate(selectedDate);
            }
        }

        private void ChargerCongesParDate(DateTime date)
        {
            using (var context = new ApplicationDbContext())
            {
                var congesFiltres = context.Conges
                .Include(p => p.Employe)
                .Where(c => c.Debut <= date && c.Fin >= date)
                .Select(p => new
                {
                    p.Motif,
                    p.Debut,
                    p.Fin,
                    Statut = DateTime.Now >= p.Debut && DateTime.Now <= p.Fin
                        ? "En cours"
                        : (DateTime.Now < p.Debut
                            ? "À venir"
                            : "Achevé"),
                    p.NomEmploye
                })
                .ToList();

                CongesDataGrid.ItemsSource = congesFiltres;
            }
        }

    }
}
