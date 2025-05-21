using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gestion_RH.Classes;
using Gestion_RH.Fenetres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour Info.xaml
    /// </summary>
    public partial class Info : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Employe employe;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private ObservableCollection<Cv> _lista;
        public ObservableCollection<Cv> Lista
        {
            get => _lista;
            set
            {
                _lista = value;
                OnPropertyChanged(nameof(Lista));
            }
        }
        public void ChargerCvDepuisBDD(Employe emp)
        {
            _lista =  new ObservableCollection<Cv>();
            foreach (var cv in emp.Cv.ToList())
            {
                Lista.Add(cv);
            }

        }
        
        public Info(Employe emp)
        {
            InitializeComponent();


            ((Storyboard)this.Resources["HideTaskPanel"]).Completed += (s, e) =>
            {
                TaskPanel.Visibility = Visibility.Collapsed;
            };

            var EmployeId = emp.Id;

            using var dbContext = new ApplicationDbContext();

            var employeFound = dbContext.Employes
                .Include(p => p.EmployeTaches)
                    .ThenInclude(e => e.Tache)
                .Include(d => d.Poste.Departement)
                .Include(d => d.Nation)
                .Include(d => d.Cv)
                .Where(c => c.Id == EmployeId)
                .FirstOrDefault();

            if (employeFound != null)
            {
                employe = employeFound;
            }


            ChargerCvDepuisBDD(employe);
            
            if (employe?.EmployeTaches != null)
            {
                Taches = new ObservableCollection<Tache>(employe.EmployeTaches.Select(et => et.Tache));
                //MessageBox.Show(Taches.First().Nom);
            }


            NomTextBox.Text = employe.Nom;
            PrenomTextBox.Text = employe.Prenom;
            EmailTextBox.Text = employe.Email;
            TelTextBox.Text = employe.Tel;
            AdresseTextBox.Text = employe.Adresse;
            PosteTextBox.Text = employe.NomPoste;
            DepartementTextBox.Text = employe.Poste?.Departement?.Nom ?? "Aucun";
            SexeTextBox.Text = employe.Genre;
            NationaliteTextBox.Text = employe.Nation?.Peuple;
            DateIntegrationPicker.SelectedDate = employe.DateIntegration;
            DateNaissancePicker.SelectedDate = employe.DateNaissance;
            if (employe.Photo != null && employe.Photo.Length > 0)
            {
                PhotoBrush.ImageSource = ByteArrayToImage(employe.Photo);
                AjouterPhotoBoutton.Visibility = Visibility.Collapsed;
                ChangerPhotoBoutton.Visibility = Visibility.Visible;
                //SupprimerPhotoBoutton.Visibility = Visibility.Visible;
            }
            else
            {
                AjouterPhotoBoutton.Visibility = Visibility.Visible;
                ChangerPhotoBoutton.Visibility = Visibility.Collapsed;
                //SupprimerPhotoBoutton.Visibility = Visibility.Collapsed;
                PhotoBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/pdpVide.jpg"));
            }
            if (employe.Empreinte != null && employe.Empreinte.Length > 0)
            {
                AjouterEmpreinteBoutton.Visibility = Visibility.Collapsed;
            }
            else
            {
                AjouterEmpreinteBoutton.Visibility = Visibility.Visible;
            }
            
            DataContext = this;
        }

        private void BtnTasks_Click(object sender, RoutedEventArgs e)
        {
            TaskPanel.Visibility = Visibility.Visible;
            var storyboard = (Storyboard)this.Resources["ShowTaskPanel"];
            storyboard.Begin();

        }
        private void TextTasks_Click(object sender, RoutedEventArgs e)
        {
            var hide = (Storyboard)this.Resources["HideTaskPanel"];
            hide.Begin();
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
        public void Rafraichir()
        {
            NavigationService.Navigate(new Info(employe));
        }

        private void UpdateEmploye_Click(object sender, RoutedEventArgs e)
        {
            UpdateEmploye modifWindow = new UpdateEmploye(this,employe);
            modifWindow.ShowDialog();

        }

        private void Bull_Click(object sender, RoutedEventArgs e)
        {
            AfficherBulletin(employe);
        }
        public void AfficherBulletin(Employe employe)
        {
            NavigationService.Navigate(new BulletinPaie(employe));
        }


        private void DeletePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (employe is Employe employeSelectionne)
            {

                using var dbContext = new ApplicationDbContext();
                var employe = dbContext.Employes.Find(employeSelectionne.Id);

                if (employe != null)
                {
                    employe.Photo = Array.Empty<byte>();
                    dbContext.SaveChanges();

                    MessageBox.Show("Photo supprimée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                    PhotoBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/pdpVide.jpg")); ;
                    AjouterPhotoBoutton.Visibility = Visibility.Visible;
                    ChangerPhotoBoutton.Visibility = Visibility.Collapsed;
                    //Afficher("employes");

                }
            }
        }
        private void AssignPhoto_Click(object sender, RoutedEventArgs e)
        {
            if (employe is Employe employeSelectionne)
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

                        PhotoBrush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                        MessageBox.Show("Photo enregistrée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                        //Afficher("employes");
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
            if (employe is Employe employeSelectionne)
            {
                using var dbContext = new ApplicationDbContext();
                var employe = dbContext.Employes.Find(employeSelectionne.Id);

                if (employe != null)
                {
                    employe.Empreinte = GenererEmpreinteSimulee();
                    dbContext.SaveChanges();

                    MessageBox.Show("Empreinte enregistrée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    //Afficher("employes");
                    AjouterEmpreinteBoutton.Visibility = Visibility.Collapsed;

                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un employé avant d'ajouter une empreinte.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Accueil()); // Naviguer vers la page d'accueil
        }
        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag is Tache task)
            {
                NavigationService.Navigate(new Detail(task));
            }
        }

        private void DownloadSupport_Click(object sender, RoutedEventArgs e)
        {
            // On suppose que l'ID du support est passé via le Tag du bouton
            int cvId = Convert.ToInt32(((Button)sender).Tag);

            using (var context = new ApplicationDbContext())
            {
                // Récupérer le support en utilisant l'ID
                var cv = context.Cvs.FirstOrDefault(s => s.Id == cvId);

                if (cv != null)
                {
                    // Créer un SaveFileDialog pour permettre à l'utilisateur de choisir l'emplacement du fichier
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Tous les fichiers (*.*)|*.*",
                        FileName = "fichier_support"  // Nom par défaut
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        // Écrire le tableau de bytes dans le fichier spécifié
                        File.WriteAllBytes(saveFileDialog.FileName, cv.Fichier);
                        MessageBox.Show("Fichier téléchargé avec succès !");
                    }
                }
                else
                {
                    MessageBox.Show("Support non trouvé.");
                }
            }
        }
        private void AddCV_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Tous les fichiers (*.*)|*.*",
                Title = "Sélectionner un fichier"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                byte[] fileBytes = File.ReadAllBytes(openFileDialog.FileName);
                Cv CV = new Cv
                {
                    NomFichier = System.IO.Path.GetFileName(openFileDialog.FileName),
                    Fichier = fileBytes,
                    EmployeId = employe.Id
                };

                if (!string.IsNullOrEmpty(CV.NomFichier))
                {
                    using var dbContext = new ApplicationDbContext();

                    dbContext.Cvs.Add(CV);
                    dbContext.SaveChanges();
                    MessageBox.Show("Curriculum vitae bien ajouté.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Lista.Add(CV);
                }
            }
        }
        private void SupprimerCV_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int id)
            {
                // Demande de confirmation
                MessageBoxResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer cette pièce?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using var dbContext = new ApplicationDbContext();

                    var cv = dbContext.Cvs.Find(id);
                    if (cv != null)
                    {
                        dbContext.Cvs.Remove(cv);
                        dbContext.SaveChanges();
                        MessageBox.Show("Pièce supprimée avec succès !");
                        var element = Lista.FirstOrDefault(cv => cv.Id == id);
                        if (element != null)
                        {
                            Lista.Remove(element);
                        }
                    }
                };
            }
        }
    }
}
