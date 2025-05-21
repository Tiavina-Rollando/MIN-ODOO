using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WPF;
using LiveChartsCore.Measure;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gestion_RH.Classes;
using Gestion_RH.Fenetres;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestion_RH.Pages;
using System.Collections.ObjectModel;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;


namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour Principale.xaml
    /// </summary>
    public partial class Principale : Page
    {
        public ISeries[] LineSeries { get; set; }
        public Axis[] XAxesL { get; set; }
        public Axis[] YAxesL { get; set; }
        public Axis[] XAxesC { get; set; }
        public Axis[] YAxesC { get; set; }
        public ISeries[] ColumnSeries { get; set; }
        public ISeries[] PieSeries { get; set; }
        public List<Tache> Taches = new List<Tache>();

        private Employe user { get; set; } = new Employe();

        public Principale(Employe sujet)
        {
            InitializeComponent();
            user = sujet;
            chargerEmploye(user);
            List<EmployeTache> taskOwn = user.EmployeTaches.ToList();
            if (taskOwn != null)
            {
                foreach ( EmployeTache tO in taskOwn)
                {
                    if(tO != null && tO.Tache != null)
                    {
                        Taches.Add(tO.Tache);
                    }
                }
            }
            ChecklistTasksBox.ItemsSource = Taches;
            BienvenuText.Text = $"Bienvenu(e) dans votre espace, {user.Prenom} {user.Nom} 👋";

            LineSeries = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] { 600, 650, 800, 750, 400, 600, 300, 550, 280, 650, 380, 450 },
                    Name = "K Ariary"
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
                    Name = "Salaire",
                    MinLimit = 0
                }
            };

            ColumnSeries = new ISeries[]
            {
                new ColumnSeries<int> { Values = new int[] { 2, 0, 0, 7, 0, 1, 0, 10, 0, 0, 0, 0 } }
            };

            XAxesC = XAxesL;

            YAxesC = new Axis[]
            {
                new Axis
                {
                    Name = "Nombre de jours",
                    MinLimit = 0
                }
            };

            PieSeries = new ISeries[]
            {
                new PieSeries<double> { Values = new double[] { 28 }, Name = "Présents" },
                new PieSeries<double> { Values = new double[] { 2 }, Name = "Absents" },
                new PieSeries<double> { Values = new double[] { 3 }, Name = "En retard" }
            };

            DataContext = this;
        }
        private BitmapImage ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                return bitmap;
            }
        }
        private void chargerEmploye(Employe sujet)
        {
            using var db = new ApplicationDbContext();
            var employe = db.Employes.SingleOrDefault(e => e.Id == sujet.Id);
            if (employe.Photo != null && employe.Photo.Length > 0)
            {
                PhotoBrush.ImageSource = ByteArrayToImage(employe.Photo);
            }
            else
            {
                PhotoBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/pdpVide.jpg"));
            }
        }
        private void ChangerMdp_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                       "Vous voulez modifier votre mot de passe?",
                       "Confirmation",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                EditPass editWindow = new EditPass(user);
                editWindow.ShowDialog();
            }
        }

        private void DemanderConge_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                   "Vous voulez envoyer une demande de congé?",
                   "Confirmation",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                RequestConge reqWindow = new RequestConge(user);
                reqWindow.ShowDialog();
            }
        }
        private void AfficherTaches_Click(object sender, RoutedEventArgs e)
        {
            Page.Visibility = Visibility.Collapsed;
            ListTask.Visibility = Visibility.Visible;
            if(Taches == null)
            {
                MessageBox.Show("Il n'y a pas de tâche pour vous pour le moment !");
            }
            else
            {
                card.ItemsSource = Taches;
            }
        }
        private void HistoriquePaie_Click(object sender, RoutedEventArgs e)
        {
            // Ouvre une nouvelle fenêtre pour afficher l'historique
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ListTask.Visibility = Visibility.Collapsed;
            Page.Visibility = Visibility.Visible;
        }
        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                   "Êtes-vous sûr de vouloir quitter votre espace?",
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
