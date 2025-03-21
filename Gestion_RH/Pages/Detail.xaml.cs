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
using Microsoft.Win32;
using Gestion_RH.Classes;
using System.Runtime.Intrinsics.Arm;
using System.IO;
using Gestion_RH.Fenetres;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Bogus;

namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour Detail.xaml
    /// </summary>
    /// 

    public partial class Detail : Page
    {
        private Tache tache { get; set; }

        private bool _renduVisible;

        private bool _responsableVisible;

        public bool RenduVisible
        {
            get { return _renduVisible; }
            set
            {
                _renduVisible = value;
                OnPropertyChanged(nameof(RenduVisible));
            }
        }

        public bool ResponsableVisible
        {
            get { return _responsableVisible; }
            set
            {
                _responsableVisible = value;
                OnPropertyChanged(nameof(ResponsableVisible));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<Support> _supportLista;
        public ObservableCollection<Support> SupportLista {
            get => _supportLista;
            set
            {
                _supportLista = value;
                OnPropertyChanged(nameof(SupportLista));
            }
        }
        public void ChargerSupportDepuisBDD(Tache task)
        {
            foreach (var support in task.Supports.ToList())
            {
                SupportLista.Add(support);
            }
           
        }
        public Detail(Tache task)
        {
            InitializeComponent();
            tache = task;
            SupportLista = new ObservableCollection<Support>();
            DataContext = this;

            ChargerSupportDepuisBDD(tache);


            var responsable = tache.EmployeTaches.FirstOrDefault();
            if (responsable != null)
            {
                string employeNom = responsable.Employe.Nom +" " + responsable.Employe.Prenom;
                string dep = responsable.Employe.NomDepartement;
                ResponsableTextBox.Text = employeNom;
                DepartementTextBox.Text = dep;
                //Console.WriteLine($"L'employé assigné à cette tâche est : {employeNom}");
                ResponsableVisible = true;
                //MessageBox.Show($"La tache est deja assigne a {responsable.Employe.Nom}");
            }
            else
            {
                ResponsableTextBox.Text = string.Empty;
                DepartementTextBox.Text = string.Empty;
                Console.WriteLine("Aucun employé assigné à cette tâche.");
                ResponsableVisible = false;
            }

            // Remplir les champs de la tâche
            ObjetTextBox.Text = task.Nom;

            DateExpeditionPicker.SelectedDate = task.DateExpedition;
            DateDeadlinePicker.SelectedDate = task.Deadline;
            DateRenduPicker.SelectedDate = task.Statut ? task.DateRendu : null;

            StatutTextBox.Text = task.Statut? "Achevée":"Inachevée";

            RenduVisible = task.Statut;
            
        }

        private void AssignEmploye_Click(object sender, RoutedEventArgs e)
        {
            ChoixEmploye assignWindow = new ChoixEmploye(tache);
            assignWindow.ShowDialog();
        }
        private void UpdateTache_Click(object sender, RoutedEventArgs e)
        {
            UpdateTache modifWindow = new UpdateTache(tache);
            modifWindow.ShowDialog();

        }
        private async void Validate_Click(object sender, RoutedEventArgs e)
        {
            if (tache is Tache tacheSelectionne)
            {

                using var dbContext = new ApplicationDbContext();
                var tache = dbContext.Taches.Find(tacheSelectionne.Id);

                if (tache != null)
                {
                    tache.Statut = true;
                    tache.DateRendu = DateTime.UtcNow;
                    dbContext.SaveChanges();

                    MessageBox.Show("La tâche a été marquée comme achevée.");
                    InitializeComponent();
                }
            }
        }

        private void DownloadSupport_Click(object sender, RoutedEventArgs e)
        {
            // On suppose que l'ID du support est passé via le Tag du bouton
            int supportId = Convert.ToInt32(((Button)sender).Tag);

            using (var context = new ApplicationDbContext())
            {
                // Récupérer le support en utilisant l'ID
                var support = context.Supports.FirstOrDefault(s => s.Id == supportId);

                if (support != null)
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
                        File.WriteAllBytes(saveFileDialog.FileName, support.Fichier);
                        MessageBox.Show("Fichier téléchargé avec succès !");
                    }
                }
                else
                {
                    MessageBox.Show("Support non trouvé.");
                }
            }
        }


        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Accueil()); // Naviguer vers la page d'accueil
        }


    }
}
