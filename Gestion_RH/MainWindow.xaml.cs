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
        private bool _employesVisible;
        private bool _ajoutEmployeVisible;
        private bool _ajoutBouttonVisible;
        private bool _infoEmployeVisible;

        public bool AjoutBouttonVisible
        {
            get { return _ajoutBouttonVisible; }
            set
            {
                _ajoutBouttonVisible = value;
                OnPropertyChanged(nameof(AjoutBouttonVisible));
            }
        }
        public bool InfoEmployeVisible
        {
            get { return _infoEmployeVisible; }
            set
            {
                _infoEmployeVisible = value;
                OnPropertyChanged(nameof(InfoEmployeVisible));
            }
        }
        public bool AjoutEmployeVisible
        {
            get { return _ajoutEmployeVisible; }
            set
            {
                _ajoutEmployeVisible = value;
                OnPropertyChanged(nameof(AjoutEmployeVisible));
            }
        }
        public bool EmployesVisible
        {
            get { return _employesVisible; }
            set
            {
                _employesVisible = value;
                OnPropertyChanged(nameof(EmployesVisible));
            }
        }
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
            EmployesVisible = false;
            AjoutEmployeVisible = false;
            AjoutBouttonVisible = true;
            InfoEmployeVisible = false;
        }


        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string classe)
            {
                if (classe == "employes")
                {
                    AjoutVisible = !AjoutVisible;
                    AjoutBouttonVisible = false;
                    using (var dbContext = new ApplicationDbContext())
                    {
                        var paysListe = dbContext.Nations.ToList();
                        PaysComboBox.ItemsSource = paysListe;
                        var roleListe = dbContext.Roles.ToList();
                        RolesComboBox.ItemsSource = roleListe;
                        var posteListe = dbContext.Postes.ToList();
                        PostesComboBox.ItemsSource = posteListe;
                    }
                    AjoutEmployeVisible = !AjoutEmployeVisible;
                }
                else 
                {
                    MessageBox.Show($"Ajout de nouveaux {classe} pas encore disponible.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public void AfficherEmployeDetails(Employe employe)
        {
            InfoEmployeVisible = true;
            // Remplir les champs du formulaire avec les données de l'employé
            NomTextBox.Text = employe.Nom;
            PrenomTextBox.Text = employe.Prenom;
            EmailTextBox.Text = employe.Email;
            TelTextBox.Text = employe.Tel;
            AdresseTextBox.Text = employe.Adresse;
            PosteTextBox.Text = employe.NomPoste;
            DepartementTextBox.Text = employe.Poste?.Departement?.Nom ?? "Aucun" ;
            SexeTextBox.Text = employe.Genre;
            NationaliteTextBox.Text = employe.Nation?.Peuple;
            DateIntegrationPicker.SelectedDate = employe.DateIntegration;
            DateNaissancePicker.SelectedDate = employe.DateNaissance;
        }

        private void EmployeSelectionne(object sender, RoutedEventArgs e)
        {
            var employe = EmployesDataGrid.SelectedItem;
            if (employe is Employe employeI)
            {
                AfficherEmployeDetails(employeI);
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            AjoutVisible = false;
            AjoutEmployeVisible = false;
            AjoutBouttonVisible = true;
        }
        private void AjouterListe_Click(object sender, RoutedEventArgs e)
        {
            AjoutVisible = !AjoutVisible; // Basculer la visibilité
        }

        private void AfficherListe_Click(object sender, RoutedEventArgs e)
        {
            AfficherVisible = !AfficherVisible; // Basculer la visibilité
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                EmployesDataGrid.ItemsSource = employes;

                // Affecte les données au DataGrid
                EmployesDataGrid.ItemsSource = employes;
            }
            if (classe == "departements")
            {
                var departements = dbContext.Departements.ToList();
                // Affecte les données au DataGrid
                DepartementsDataGrid.ItemsSource = departements;
            }
            if (classe == "roles")
            {
                var roles = dbContext.Roles.ToList();
                // Affecte les données au DataGrid
                RolesDataGrid.ItemsSource = roles;
            }
            if (classe == "nations")
            {
                var nations = dbContext.Nations.ToList();
                // Affecte les données au DataGrid
                NationsDataGrid.ItemsSource = nations;
            }
            if (classe == "postes")
            {
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
                // Affecte les données au DataGrid
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
                        InfoEmployeVisible = false;
                        DepartementsVisible = !DepartementsVisible;
                        break;
                    case "postes":
                        InfoEmployeVisible = false;
                        PostesVisible = !PostesVisible;
                        break;
                    case "nations":
                        InfoEmployeVisible = false;
                        NationsVisible = !NationsVisible;
                        break;
                    case "roles":
                        InfoEmployeVisible = false;
                        RolesVisible = !RolesVisible;
                        break;
                    case "employes":
                        if(EmployesDataGrid.SelectedItem == null)
                        {
                            InfoEmployeVisible = false;
                        }
                        else
                        {
                        InfoEmployeVisible = !InfoEmployeVisible;
                        }
                        EmployesVisible = !EmployesVisible;
                        break;
                }
            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Supprimer ?");
            if (sender is Button button)
            {
                // Afficher ce que contient le sender et le Tag pour déboguer
                MessageBox.Show($"Sender: {sender.GetType().Name}, Tag: {button.Tag}");

                if (button.Tag is string tag)
                {
                    // Déboguer le contenu du Tag
                    MessageBox.Show($"Tag: {tag}");

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
                        }
                        // Rafraîchir la liste
                        Afficher(classe);
                    }
                }
            }
        }

        private void Inserer_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string classe)
            {
                if (classe == "employes")
                {
                    Employe novice = new Employe()
                    {
                        Nom = NomEmployeTextBox.Text.Trim(),
                        Prenom = PrenomEmployeTextBox.Text.Trim(),
                        Email = EmailEmployeTextBox.Text.Trim(),
                        Adresse = AdresseEmployeTextBox.Text.Trim(),
                        Tel = TelEmployeTextBox.Text.Trim(),
                        Sexe = ((ComboBoxItem)SexeEmployeComboBox.SelectedItem).Content.ToString() == "Homme",
                        IdNation = (int)PaysComboBox.SelectedValue,
                        IdPoste = (int)PostesComboBox.SelectedValue,
                        IdRole = (int)RolesComboBox.SelectedValue,
                        DateIntegration = DateIntegrationEmployePicker.SelectedDate ?? DateTime.Now,
                        DateNaissance = DateNaissanceEmployePicker.SelectedDate

                    };

                    if (!string.IsNullOrEmpty(novice.Nom))
                    {
                        using var dbContext = new ApplicationDbContext();

                        dbContext.Employes.Add(novice);
                        dbContext.SaveChanges();
                        MessageBox.Show("Employé bien enregistré.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        // Rafraîchir la liste des départements
                        Afficher("employes");

                        // Vider le champ de saisie
                        NomEmployeTextBox.Clear();
                    }
                    else 
                    {
                        MessageBox.Show("Veuillez entrer un nom valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }
    }
}
