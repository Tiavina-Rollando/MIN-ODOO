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
using Gestion_RH.Pages;
using Gestion_RH.Services;
using Microsoft.EntityFrameworkCore;

namespace Gestion_RH.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour resetPass.xaml
    /// </summary>
    public partial class EditPass : Window
    {
        private Employe user = new Employe();
        public EditPass(Employe sujet)
        {
            InitializeComponent();
            user = sujet;
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string ancien = OldPassBox.Password.Trim();
            string nouveau = NewPassBox.Password.Trim();
            string confirmation = NewPassConfBox.Password.Trim();

            if (string.IsNullOrEmpty(ancien) || string.IsNullOrEmpty(nouveau) || string.IsNullOrEmpty(confirmation))
            {
                MessageBox.Show("Tous les champs sont obligatoires !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (nouveau != confirmation)
            {
                MessageBox.Show("Le nouveau mot de passe et sa confirmation ne correspondent pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using var db = new ApplicationDbContext();
            var employe = db.Employes.SingleOrDefault(e => e.Id == user.Id);

            if (employe == null)
            {
                MessageBox.Show("Utilisateur introuvable.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!PasswordHelper.Verifier(ancien,employe.Mdp))
            {
                MessageBox.Show("L'ancien mot de passe est incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            employe.Mdp = PasswordHelper.Hasher(nouveau);
            db.SaveChanges();

            MessageBox.Show("Mot de passe mis à jour avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

    }
}
