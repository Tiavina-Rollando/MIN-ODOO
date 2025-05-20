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
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using Microsoft.EntityFrameworkCore;

namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour Conge.xaml
    /// </summary>
    public partial class Conge : Page, INotifyPropertyChanged
    {
        public ObservableCollection<string> ListeDesNoms { get; set; } = new ObservableCollection<string>
            {
                "ANDRIAMANANTSOA Tiavina Rollando",
                "RAKOTONDRABE Haja Manitra",
                "RAZAFINDRAKOTO Fanja"
            };

        public ISeries[] LineSeries { get; set; }
        public Axis[] XAxesL { get; set; }
        public Axis[] YAxesL { get; set; }
        public Axis[] XAxesC { get; set; }
        public Axis[] YAxesC { get; set; }
        public ISeries[] ColumnSeries { get; set; }
        public ISeries[] PieSeries { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<DemandeConge> _demandes;
        public ObservableCollection<DemandeConge> Demandes
        {
            get => _demandes;
            set
            {
                _demandes = value;
                OnPropertyChanged(nameof(Demandes));
            }
        }
        private bool _demandesVisible;


        public bool DemandesVisible
        {
            get { return _demandesVisible; }
            set
            {
                _demandesVisible = value;
                OnPropertyChanged(nameof(DemandesVisible));
            }
        }
        private bool _congesVisible;


        public bool CongesVisible
        {
            get { return _congesVisible; }
            set
            {
                _congesVisible = value;
                OnPropertyChanged(nameof(CongesVisible));
            }
        }
        
        private DemandeConge demandeSelect { get; set; }
        public void ChargerNewRequestDepuisBDD()
        {
            using (var db = new ApplicationDbContext())
            {
                _demandes = new ObservableCollection<DemandeConge>();
                Demandes.Clear();
                foreach (var dem in db.DemandesConge
                    .Include(d => d.Employe)
                        .ThenInclude(e => e.Poste)
                            .ThenInclude(p => p.Departement)
                    .Include(d => d.Employe)
                        .ThenInclude(e => e.Conges)
                    .Where(d => d.Statut == StatutDemandeConge.Nouveau || d.Statut == StatutDemandeConge.EnAttente)
                    .ToList())
                {
                    Demandes.Add(dem);
                }
            }
        }
        public void Rafraichir()
        {
            NavigationService.Navigate(new Conge());
        }
        public Conge()
        {
            InitializeComponent();
            LineSeries = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] { 3, 5, 2, 7, 4, 6, 3, 5, 2, 6, 3, 4 },
                    Name = "Employés en congé"
                }
            };
            XAxesL = new Axis[]
            {
                new Axis
                {
                    Labels = new string[] { "Jan", "Fév", "Mar", "Avr", "Mai", "Juin", "Juil", "Août", "Sep", "Oct", "Nov", "Déc" },
                    LabelsRotation = 15
                }
            };

            YAxesL = new Axis[]
            {
                new Axis
                {
                    Name = "Nombre d'employés",
                    MinLimit = 0
                }
            };

            ColumnSeries = new ISeries[]
            {
                new ColumnSeries<int> { Values = new int[] { 5, 3, 7, 4, 1 } }
            };

            XAxesC = new Axis[]
            {
                new Axis
                {
                    Labels = new string[] { "IT", "Finance", "RH", "COM", "JC"},
                    LabelsRotation = 15
                }
            };

            YAxesC = new Axis[]
            {
                new Axis
                {
                    Name = "Nombre d'employés",
                    MinLimit = 0
                }
            };

            PieSeries = new ISeries[]
            {
                new PieSeries<double> { Values = new double[] { 40 }, Name = "Présents" },
                new PieSeries<double> { Values = new double[] { 30 }, Name = "Absents" },
                new PieSeries<double> { Values = new double[] { 30 }, Name = "En retard" }
            };


            DataContext = this;

            Afficher();
            ((Storyboard)this.Resources["HideNotificationPanel"]).Completed += (s, e) =>
            {
                NotificationPanel.Visibility = Visibility.Collapsed;
            };
            ChargerNewRequestDepuisBDD();
            CongesVisible = true;
            DemandesVisible = false;
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
            DemandesVisible = true;
            CongesVisible = false;
            View.Visibility = Visibility.Collapsed;
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            var hide = (Storyboard)this.Resources["HideNotificationPanel"];
            hide.Begin();
            DemandesVisible = false;
            CongesVisible = true;
            View.Visibility = Visibility.Collapsed;
        }
        private void View_Click(object sender, RoutedEventArgs e)
        {
            View.Visibility = Visibility.Visible;
            CongesVisible = false;
            DemandesVisible = false;
            if (sender is Button button && button.Tag is DemandeConge dem)
            {
                demandeSelect = new DemandeConge();
                demandeSelect = dem;
                using var dbContext = new ApplicationDbContext();
                var demande = dbContext.DemandesConge
                    .Where(d => d.Id == demandeSelect.Id)
                    .SingleOrDefault();
                demande.Statut = StatutDemandeConge.EnAttente;
                dbContext.SaveChanges();
            }
        }
        private void Agree_Click(object sender, RoutedEventArgs e)
        {
            // Demande de confirmation
            MessageBoxResult result = MessageBox.Show(
                "Êtes-vous sûr de vouloir approuver celle-ci?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using var dbContext = new ApplicationDbContext();
                var demande = dbContext.DemandesConge
                    .Where(d=>d.Id==demandeSelect.Id)
                    .SingleOrDefault();
                demande.Statut = StatutDemandeConge.Approuve;
                Gestion_RH.Classes.Conge c = new Gestion_RH.Classes.Conge();
                c.Motif = demande.Motif;
                c.Debut = demande.Debut;
                c.Fin = demande.Fin;
                c.DemandeId = demande.Id;
                c.EmployeId = demande.EmployeId;
                dbContext.Conges.Add(c);
                dbContext.SaveChanges();
                MessageBox.Show("Demande de congé approuvée avec succès !");
                Rafraichir();
            }
        }
        private void Disagree_Click(object sender, RoutedEventArgs e)
        {
            // Demande de confirmation
            MessageBoxResult result = MessageBox.Show(
                "Êtes-vous sûr de vouloir réfuser celle-ci?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using var dbContext = new ApplicationDbContext();
                var demande = dbContext.DemandesConge
                    .Where(d => d.Id == demandeSelect.Id)
                    .SingleOrDefault();
                demande.Statut = StatutDemandeConge.Refuse;
                dbContext.SaveChanges();

                MessageBox.Show("Demande de congé refusée!");
                Rafraichir();
            }
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

            var demandes = dbContext.DemandesConge
                .Include(p => p.Employe)
                .Select(p => new
                {
                    p.Motif,
                    p.Debut,
                    p.Envoye,
                    p.Fin,
                    p.Statut,
                    p.StatutImage,
                    p.TextStatut,
                    p.NomEmploye
                })
                .ToList();

            DemandesDataGrid.ItemsSource = demandes;
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
