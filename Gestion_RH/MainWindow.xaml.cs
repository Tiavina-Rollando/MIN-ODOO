using System;
using System.Collections.Generic;
using System.Windows;
using Gestion_RH.Services;
using Gestion_RH.Classes;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Gestion_RH
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _ajoutVisible;
        private bool _afficherVisible;
        private bool _departementsVisible;
        private bool _postesVisible;
        private bool _nationsVisible;
        private bool _rolesVisible;


        public bool AjoutVisible
        {
            get { return _ajoutVisible; }
            set
            {
                _ajoutVisible = value;
                OnPropertyChanged(nameof(AjoutVisible));
            }
        }
        public bool AfficherVisible
        {
            get { return _afficherVisible; }
            set
            {
                _afficherVisible = value;
                OnPropertyChanged(nameof(AfficherVisible));
            }
        }
        public bool RolesVisible
        {
            get { return _rolesVisible; }
            set
            {
                _rolesVisible = value;
                OnPropertyChanged(nameof(RolesVisible));
            }
        }
        public bool DepartementsVisible
        {
            get { return _departementsVisible; }
            set
            {
                _departementsVisible = value;
                OnPropertyChanged(nameof(DepartementsVisible));
            }
        }
        public bool PostesVisible
        {
            get { return _postesVisible; }
            set
            {
                _postesVisible = value;
                OnPropertyChanged(nameof(PostesVisible));
            }
        }
        public bool NationsVisible
        {
            get { return _nationsVisible; }
            set
            {
                _nationsVisible = value;
                OnPropertyChanged(nameof(NationsVisible));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            AjoutVisible = false;
            AfficherVisible = false;
            DepartementsVisible = false;
            PostesVisible = false;
            NationsVisible = false;
            RolesVisible = false;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            AjoutVisible = !AjoutVisible; // Basculer la visibilité
        }

        private void Afficher_Click(object sender, RoutedEventArgs e)
        {
            AfficherVisible = !AfficherVisible; // Basculer la visibilité
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AfficheDepartements()
        {
            using var dbContext = new ApplicationDbContext();
            var departements = dbContext.Departements.ToList();

            // Affecte les données au DataGrid
            DepartementsDataGrid.ItemsSource = departements;
        }
        public void AffichePostes()
        {
            using var dbContext = new ApplicationDbContext();
            var postes = dbContext.Postes
            .Include(p => p.Departement)  // 👈 Charger aussi les départements
            .Select(p => new
            {
                p.Id,
                p.Nom,
                StatutTexte = p.Statut ? "Occupé" : "Vacant",  // 🔥 Condition ici
                NomDepartement = p.Departement != null ? p.Departement.Nom : "Non attribué"  // 👈 Afficher le nom du département
            })
            .ToList();

            DepartementsDataGrid.ItemsSource = postes;
            // Affecte les données au DataGrid
            PostesDataGrid.ItemsSource = postes;
        }
        public void AfficheRoles()
        {
            using var dbContext = new ApplicationDbContext();
            var roles = dbContext.Roles.ToList();

            // Affecte les données au DataGrid
            RolesDataGrid.ItemsSource = roles;
        }
        public void AfficheNations()
        {
            using var dbContext = new ApplicationDbContext();
            var nations = dbContext.Nations.ToList();

            // Affecte les données au DataGrid
            NationsDataGrid.ItemsSource = nations;
        }
        private void AfficherDepartement_Click(object sender, RoutedEventArgs e) 
        {
            AfficheDepartements();
            DepartementsVisible = !DepartementsVisible; // Basculer la visibilité
        }
        private void AfficherPoste_Click(object sender, RoutedEventArgs e)
        {
            AffichePostes(); 
            PostesVisible = !PostesVisible; // Basculer la visibilité
        }
        private void AfficherNation_Click(object sender, RoutedEventArgs e)
        {
            AfficheNations();
            NationsVisible = !NationsVisible; // Basculer la visibilité
        }
        private void AfficherRole_Click(object sender, RoutedEventArgs e)
        {
            AfficheRoles();
            RolesVisible = !RolesVisible; // Basculer la visibilité
        }

        private void SupprimerDepartement_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is long id)
            {
                // Demande de confirmation à l'utilisateur
                MessageBoxResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer ce département ?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    // Supprimer le département de la base de données
                    using var dbContext = new ApplicationDbContext();
                    var departement = dbContext.Departements.Find(id);

                    if (departement != null)
                    {
                        dbContext.Departements.Remove(departement);
                        dbContext.SaveChanges();

                        // Rafraîchir la liste des départements
                        AfficheDepartements();

                        MessageBox.Show("Département supprimé avec succès !");
                    }
                    else
                    {
                        MessageBox.Show("Le département sélectionné n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        private void AjouterDepartement_Click(object sender, RoutedEventArgs e)
        {
            string nomDepartement = NomDepartementTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(nomDepartement))
            {
                using var dbContext = new ApplicationDbContext();
                var nouveauDepartement = new Departement { Nom = nomDepartement };

                dbContext.Departements.Add(nouveauDepartement);
                dbContext.SaveChanges();

                // Rafraîchir la liste des départements
                AfficheDepartements();

                // Vider le champ de saisie
                NomDepartementTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom de département valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
