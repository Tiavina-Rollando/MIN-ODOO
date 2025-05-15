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

namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour Principale.xaml
    /// </summary>
    public partial class Principale : Page
    {
        private Employe user { get; set; } = new Employe();
        public Principale(Employe sujet)
        {
            InitializeComponent();
            user = sujet;
            chargerEmploye(user);
            BienvenuText.Text = $"Bienvenu(e) dans votre espace, {user.Prenom} {user.Nom} 👋";
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

        private void HistoriquePaie_Click(object sender, RoutedEventArgs e)
        {
            // Ouvre une nouvelle fenêtre pour afficher l'historique
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
