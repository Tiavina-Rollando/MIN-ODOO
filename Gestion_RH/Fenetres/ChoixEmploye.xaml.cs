using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Gestion_RH.Classes;

namespace Gestion_RH.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour ChoixEmploye.xaml
    /// </summary>
    public partial class ChoixEmploye : Window
    {
        private Tache task { get; set; }
        public ChoixEmploye(Tache tache)
        {
            InitializeComponent();
            task = tache;
        }
        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is Employe employe)
            {

                using var dbContext = new ApplicationDbContext();
                dbContext.EmployeTaches.Add(new EmployeTache { EmployeId = employe.Id, TacheId = task.Id});
                dbContext.SaveChanges();

                MessageBox.Show($"{employe.Prenom} sélectionné !");
                this.Close();
            }
        }

    }
}
