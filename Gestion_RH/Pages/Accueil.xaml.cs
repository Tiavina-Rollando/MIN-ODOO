using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WPF;
using LiveChartsCore.Measure;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gestion_RH.Classes;
using Microsoft.EntityFrameworkCore;
using Gestion_RH.Pages;
using Gestion_RH.Fenetres;
using System.Collections.ObjectModel;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Page, INotifyPropertyChanged
    {
        public ISeries[] LineSeries { get; set; }
        public Axis[] XAxesL { get; set; }
        public Axis[] YAxesL { get; set; }
        public Axis[] XAxesC { get; set; }
        public Axis[] YAxesC { get; set; }
        public ISeries[] ColumnSeries { get; set; }
        public ISeries[] PieSeries { get; set; }

        private ObservableCollection<Employe> ListeEmployes { get; set; }

        private ICollectionView _viewEmployes;

        private ObservableCollection<Employe> _employesCard;
        public ObservableCollection<Employe> ListEmployesCard
        {
            get => _employesCard;
            set
            {
                _employesCard = value;
                OnPropertyChanged(nameof(ListEmployesCard));
            }
        }

        private ObservableCollection<Tache> _taches;
        public ObservableCollection<Tache> Taches
        {
            get => _taches;
            set
            {
                _taches = value;
                OnPropertyChanged(nameof(Taches));
            }
        }

        public void ChargerTachesDepuisBDD()
        {
            using (var db = new ApplicationDbContext())
            {
                Taches.Clear();
                foreach (var tache in db.Taches
                            .Include(t => t.Supports)  
                            .Include(t => t.EmployeTaches)
                                .ThenInclude(et => et.Employe)
                                    .ThenInclude(e => e.Poste)
                                        .ThenInclude(p => p.Departement)
                            .Include(t => t.Consignes)
                            .ToList())

                {
                    Taches.Add(tache);
                }
            }
        }

        public void ChargerEmployesDepuisBDD()
        {
            using (var db = new ApplicationDbContext())
            {
                ListEmployesCard.Clear();
                ListEmployesCard = new ObservableCollection<Employe>(db.Employes
                   .Include(p => p.Nation)
                    .Include(p => p.Role)
                    .Include(p => p.Poste)
                    .Include(p => p.Cv)
                    .Include(p => p.Poste.Departement)
                    .Include(p => p.EmployeTaches)
                        .ThenInclude(e => e.Tache)
                    .ToList());
            }
        }

        public Accueil()
        {
            InitializeComponent();
            Taches = new ObservableCollection<Tache>();
            ListEmployesCard = new ObservableCollection<Employe>();

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
            
            ChargerTachesDepuisBDD();
            ChecklistTasksBox.ItemsSource = Taches;
        }

        public void Rafraichir()
        {
            MessageBox.Show("Il est temps de rafraichir la page");
            ContenuAccueil.Visibility = Visibility.Visible;

            NavigationService.Navigate(new Accueil());
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is Employe employe)
            {
                AfficherEmployeDetails(employe);
            }
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string classe)
            {
                if (classe == "employes")
                {
                    AddEmploye addWindow = new AddEmploye(this);
                    addWindow.ShowDialog();

                }
                else if (classe == "taches")
                {
                    AddTask addWindow = new AddTask(this);
                    addWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Ajout de nouveaux {classe} pas encore disponible.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }


        public void AfficherEmployeDetails(Employe employe)
        {
            NavigationService.Navigate(new Info(employe));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        
        private void Parametre_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Parametre());
        }
        

        
        public void Afficher(string classe)
        {
            using var dbContext = new ApplicationDbContext();

            if (classe == "employesCard")
            {
                ChargerEmployesDepuisBDD();
            }
            if (classe == "tachesCard")
            {
                ChargerTachesDepuisBDD();
            }
        }
        private void Afficher_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string classe)
            {
                ContenuAccueil.Visibility = Visibility.Collapsed;
                Afficher(classe);

                switch (classe)
                {
                    case "tachesCard":
                        ListTask.Visibility = Visibility.Visible;
                        ListEmploye.Visibility = Visibility.Collapsed;
                        break;
                    case "employesCard":
                        ListTask.Visibility = Visibility.Collapsed;
                        ListEmploye.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag is Tache task)
            {
                NavigationService.Navigate(new Detail(task));
            }
        }

        private void Conge_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Conge());
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

                    switch (classe)
                    {
                        case "departements":
                            var departement = dbContext.Departements.Find(id);
                            if (departement != null)
                            {
                                dbContext.Departements.Remove(departement);
                                dbContext.SaveChanges();
                                MessageBox.Show("Département supprimé avec succès !");
                            }
                            break;

                        case "postes":
                            var poste = dbContext.Postes.Find(id);
                            if (poste != null)
                            {
                                dbContext.Postes.Remove(poste);
                                dbContext.SaveChanges();
                                MessageBox.Show("Poste supprimé avec succès !");
                            }
                            break;

                        case "nations":
                            var nation = dbContext.Nations.Find(id);
                            if (nation != null)
                            {
                                dbContext.Nations.Remove(nation);
                                dbContext.SaveChanges();
                                MessageBox.Show("Pays supprimé avec succès !");
                            }
                            break;

                        case "employes":
                            var employe = dbContext.Employes.Find(id);
                            if (employe != null)
                            {
                                dbContext.Employes.Remove(employe);
                                dbContext.SaveChanges();
                                MessageBox.Show("Employé supprimé avec succès !");
                            }
                            break;
                    };
                    Afficher(classe);
                }
            }
        }

        private void NewHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Accueil());
            ContenuAccueil.Visibility = Visibility.Visible;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                   "Êtes-vous sûr de vouloir quitter l'application?",
                   "Confirmation",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new Login());
            }
        }
    }
}
