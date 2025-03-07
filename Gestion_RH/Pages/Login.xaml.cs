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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void BtnCodeLogin_Click(object sender, RoutedEventArgs e)
        {
            string code = txtCode.Password; // Récupérer le code entré

            if (code == "123456") // Remplace par ton code de validation
            {
                MessageBox.Show("Connexion réussie !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Accueil()); // Naviguer vers la page d'accueil
            }
            else
            {
                MessageBox.Show("Code incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnFingerprintLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Empreinte digitale non configurée.", "Information", MessageBoxButton.OK, MessageBoxImage.Warning);
            // Ici, tu peux ajouter l'intégration avec un lecteur biométrique si nécessaire.
        }


    }
}
