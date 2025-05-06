using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.EntityFrameworkCore;
using Gestion_RH.Pages;
using Gestion_RH.Fenetres;
using System.Collections.ObjectModel;

namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour Parametre.xaml
    /// </summary>
    public partial class Parametre : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Employe> ListeEmployes { get; set; }
        private ICollectionView _viewEmployes;


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _afficherVisible;
        private bool _departementsVisible;
        private bool _postesVisible;
        private bool _nationsVisible;
        private bool _rolesVisible;
        private bool _employesVisible;

        
        public bool EmployesVisible
        {
            get { return _employesVisible; }
            set
            {
                _employesVisible = value;
                OnPropertyChanged(nameof(EmployesVisible));
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

        public Parametre()
        {
            InitializeComponent();
            DataContext = this;

            DepartementsVisible = false;
            PostesVisible = false;
            NationsVisible = false;
            RolesVisible = false;
            EmployesVisible = false;
            AfficherVisible = false;

        }
        private void AfficherListe_Click(object sender, RoutedEventArgs e)
        {
            AfficherVisible = !AfficherVisible;
        }
        public void Afficher(string classe)
        {
            using var dbContext = new ApplicationDbContext();

            if (classe == "employes")
            {
                var employes = dbContext.Employes
                    .Include(p => p.Nation)
                    .Include(p => p.Role)
                    .Include(p => p.Poste)
                    .Include(p => p.Poste.Departement)
                    .ToList();

                ListeEmployes = new ObservableCollection<Employe>(employes);

                // ✅ Création d'une vue pour la recherche et le tri
                _viewEmployes = CollectionViewSource.GetDefaultView(ListeEmployes);
                EmployesDataGrid.ItemsSource = _viewEmployes;
            }
            if (classe == "departements")
            {
                var departements = dbContext.Departements.ToList();
                DepartementsDataGrid.ItemsSource = departements;
            }
            if (classe == "roles")
            {
                var roles = dbContext.Roles.ToList();
                RolesDataGrid.ItemsSource = roles;
            }
            if (classe == "nations")
            {
                var nations = dbContext.Nations.ToList();
                NationsDataGrid.ItemsSource = nations;
            }
            if (classe == "postes")
            {
                var postes = dbContext.Postes
                .Include(p => p.Departement)
                .Select(p => new
                {
                    p.Id,
                    p.Nom,
                    StatutTexte = p.Statut ? "Occupé" : "Vacant",
                    NomDepartement = p.Departement != null ? p.Departement.Nom : "Non attribué"
                })
                .ToList();
                PostesDataGrid.ItemsSource = postes;
            }

        }
        private void Afficher_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string classe)
            {
                Afficher(classe);

                switch (classe)
                {
                    case "departements":
                        DepartementsVisible = !DepartementsVisible;
                        break;
                    case "postes":
                        PostesVisible = !PostesVisible;
                        break;
                    case "nations":
                        NationsVisible = !NationsVisible;
                        break;
                    case "roles":
                        RolesVisible = !RolesVisible;
                        break;
                    case "employes":
                        EmployesVisible = !EmployesVisible;
                        break;
                }
            }
        }
        private void EmployeSelectionne(object sender, SelectionChangedEventArgs e)
        {
            Employe employeSelectionne = new Employe();
            employeSelectionne = (Employe)EmployesDataGrid.SelectedItem;

            if (employeSelectionne is Employe employe)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Voir détails sur {employe?.Nom ?? ""} {employe?.Prenom ?? ""}?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    AfficherEmployeDetails(employe);
                }
            }
        }
        public void AfficherEmployeDetails(Employe employe)
        {
            NavigationService.Navigate(new Info(employe));
        }
        private void txtRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtre = txtRecherche.Text.ToLower();
            _viewEmployes.Filter = item =>
            {
                if (item is Employe employe)
                {
                    return employe.Nom.ToLower().Contains(filtre) || employe.Prenom.ToLower().Contains(filtre);
                }
                return false;
            };
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Accueil()); // Naviguer vers la page d'accueil
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

    }
}
