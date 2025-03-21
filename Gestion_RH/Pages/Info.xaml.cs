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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gestion_RH.Classes;
using Gestion_RH.Fenetres;
using Microsoft.Win32;

namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour Info.xaml
    /// </summary>
    public partial class Info : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Employe employe;
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
        public Info(Employe emp)
        {
            InitializeComponent();
            employe = emp;
            DataContext = this;
            if (employe?.EmployeTaches != null)
            {
                Taches = new ObservableCollection<Tache>(employe.EmployeTaches.Select(et => et.Tache));
                MessageBox.Show(Taches.First().Nom);
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
        private void UpdateEmploye_Click(object sender, RoutedEventArgs e)
        {
            UpdateEmploye modifWindow = new UpdateEmploye(employe);
            modifWindow.ShowDialog();

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
    }
}
