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
        private bool _renseignementsVisible;
        private bool _updateRenseignementsVisible;
        private Employe dernierEmployeSelectionne = new Employe();
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
        public bool RenseignementsVisible
        {
            get { return _renseignementsVisible; }
            set
            {
                _renseignementsVisible = value;
                OnPropertyChanged(nameof(RenseignementsVisible));
            }
        }
        public bool UpdateBoxVisible
        {
            get { return _updateRenseignementsVisible; }
            set
            {
                _updateRenseignementsVisible = value;
                OnPropertyChanged(nameof(UpdateBoxVisible));
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

            using (var dbContext = new ApplicationDbContext())
            {
                var paysListe = dbContext.Nations.ToList();
                PaysComboBox.ItemsSource = paysListe;
                PaysUpdateComboBox.ItemsSource = paysListe;
                var roleListe = dbContext.Roles.ToList();
                RolesComboBox.ItemsSource = roleListe;
                var posteListe = dbContext.Postes.ToList();
                PostesComboBox.ItemsSource = posteListe;
                PostesUpdateComboBox.ItemsSource = posteListe;
            }
        }


        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string classe)
            {
                if (classe == "employes")
                {
                    AjoutVisible = !AjoutVisible;
                    AjoutBouttonVisible = false;
                    AjoutEmployeVisible = !AjoutEmployeVisible;
                }
                else 
                {
                    MessageBox.Show($"Ajout de nouveaux {classe} pas encore disponible.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
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

        public void AfficherEmployeDetails(Employe employe)
        {
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
            if (employe.Photo != null && employe.Photo.Length > 0)
            {
                PhotoEmployeImage.Source = ByteArrayToImage(employe.Photo);
                AjouterPhotoBoutton.Visibility = Visibility.Collapsed;
                ChangerPhotoBoutton.Visibility = Visibility.Visible;
                SupprimerPhotoBoutton.Visibility = Visibility.Visible;
            }
            else
            {
                AjouterPhotoBoutton.Visibility = Visibility.Visible;
                ChangerPhotoBoutton.Visibility = Visibility.Collapsed;
                SupprimerPhotoBoutton.Visibility = Visibility.Collapsed;
                PhotoEmployeImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/pdpVide.jpg"));
            }
            if (employe.Empreinte != null && employe.Empreinte.Length > 0)
            {
                AjouterEmpreinteBoutton.Visibility = Visibility.Collapsed;
            }
            else
            {
                AjouterEmpreinteBoutton.Visibility = Visibility.Visible;
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
                    InfoEmployeVisible = true;
                    RenseignementsVisible = true;
                    UpdateBoxVisible = false;
                    AfficherEmployeDetails(employe);
                }
             }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            AjoutVisible = false;
            AjoutEmployeVisible = false;
            AjoutBouttonVisible = true;
        }

        private void HideInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoEmployeVisible = false;
        }
        private void AjouterListe_Click(object sender, RoutedEventArgs e)
        {
            AjoutVisible = !AjoutVisible;
        }

        private void AfficherListe_Click(object sender, RoutedEventArgs e)
        {
            AfficherVisible = !AfficherVisible; 
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
            };
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
                        InfoEmployeVisible = false;
                        EmployesVisible = !EmployesVisible;
                        break;
                }
            }
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
                    InfoEmployeVisible = false;
                    Afficher(classe);
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
                        
                        Afficher("employes");

                        NomEmployeTextBox.Clear();
                        PrenomEmployeTextBox.Clear();
                        
                    }
                    else 
                    {
                        MessageBox.Show("Veuillez entrer un nom valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void DeletePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (EmployesDataGrid.SelectedItem is Employe employeSelectionne)
            {

                using var dbContext = new ApplicationDbContext();
                var employe = dbContext.Employes.Find(employeSelectionne.Id);

                if (employe != null)
                {
                    employe.Photo = Array.Empty<byte>();
                    dbContext.SaveChanges();

                    MessageBox.Show("Photo supprimée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Mettre à jour l'affichage
                    PhotoEmployeImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/pdpVide.jpg")); ;
                    AjouterPhotoBoutton.Visibility = Visibility.Visible;
                    ChangerPhotoBoutton.Visibility = Visibility.Collapsed;
                    Afficher("employes");

                }
            }
        }
        private void AssignPhoto_Click(object sender , RoutedEventArgs e)
        {
            if (EmployesDataGrid.SelectedItem is Employe employeSelectionne)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Images (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                    Title = "Sélectionner une photo"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    byte[] photoBytes = File.ReadAllBytes(openFileDialog.FileName);
                    using var dbContext = new ApplicationDbContext();
                    var employe = dbContext.Employes.Find(employeSelectionne.Id);

                    if (employe != null)
                    {
                        employe.Photo = photoBytes;
                        dbContext.SaveChanges();

                        PhotoEmployeImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                        MessageBox.Show("Photo enregistrée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                        Afficher("employes");
                        AjouterPhotoBoutton.Visibility = Visibility.Collapsed;
                        ChangerPhotoBoutton.Visibility = Visibility.Visible;

                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un employé avant d'ajouter une photo.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private byte[] GenererEmpreinteSimulee()
        {
            byte[] empreinteFausse = new byte[256]; // Simule une empreinte de 256 octets
            Random random = new Random();
            random.NextBytes(empreinteFausse);
            return empreinteFausse;
        }

        private void AssignDigit_Click(object sender, RoutedEventArgs e)
        {
            if (EmployesDataGrid.SelectedItem is Employe employeSelectionne)
            {
                using var dbContext = new ApplicationDbContext();
                var employe = dbContext.Employes.Find(employeSelectionne.Id);

                if (employe != null)
                {
                    employe.Empreinte = GenererEmpreinteSimulee();
                    dbContext.SaveChanges();

                    MessageBox.Show("Empreinte enregistrée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    Afficher("employes");
                    AjouterEmpreinteBoutton.Visibility = Visibility.Collapsed;

                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un employé avant d'ajouter une empreinte.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateEmploye_Click(object sender , RoutedEventArgs e)
        {
            RenseignementsVisible = false;
            UpdateBoxVisible = true;

            NomTextUpdateBox.Text = NomTextBox.Text;
            PrenomTextUpdateBox.Text = PrenomTextBox.Text;
            EmailTextUpdateBox.Text = EmailTextBox.Text;
            AdresseTextUpdateBox.Text = AdresseTextBox.Text;
            TelTextUpdateBox.Text = TelTextBox.Text;
            DateIntegrationUpdatePicker.Text = DateIntegrationPicker.Text;
            DateNaissanceUpdatePicker.Text = DateNaissancePicker.Text;

        }

        private void SaveUpdateEmploye_Click(object sender, RoutedEventArgs e)
        {   
            if (EmployesDataGrid.SelectedItem is Employe employeSelectionne)
            {
                using var dbContext = new ApplicationDbContext();
                var employe = dbContext.Employes.Find(employeSelectionne.Id);

                if (employe != null)
                {
                    employe.Nom = NomTextUpdateBox.Text.Trim();
                    employe.Prenom = PrenomTextUpdateBox.Text.Trim();
                    employe.Email = EmailTextUpdateBox.Text.Trim();
                    employe.Adresse = AdresseTextUpdateBox.Text.Trim();
                    employe.Tel = TelTextUpdateBox.Text.Trim();
                    employe.Sexe = ((ComboBoxItem)SexeUpdateComboBox.SelectedItem).Content.ToString() == "Homme";
                    employe.IdNation = (int)PaysUpdateComboBox.SelectedValue;
                    employe.IdPoste = (int)PostesUpdateComboBox.SelectedValue;
                    employe.DateIntegration = DateIntegrationUpdatePicker.SelectedDate ?? DateTime.Now;
                    employe.DateNaissance = DateNaissanceUpdatePicker.SelectedDate;

                    MessageBoxResult result = MessageBox.Show(
                            $"Valider les mises à jour sur {employe?.Nom ?? ""} {employe?.Prenom ?? ""}?",
                            "Confirmation",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        dbContext.SaveChanges();
                        MessageBox.Show("Employé modifié avec succès.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                        Afficher("employes");

                        InfoEmployeVisible = false;
                    } 
                }

            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un employé à modifier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
