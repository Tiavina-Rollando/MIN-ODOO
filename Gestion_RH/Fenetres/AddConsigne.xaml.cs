using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Gestion_RH.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour AddConsigne.xaml
    /// </summary>
    public partial class AddConsigne : Window
    {
        // Collection de consignes
        public ObservableCollection<string> Consignes { get; set; }
        
        public AddConsigne(ObservableCollection<string> consignes)
        {
            InitializeComponent();
            Consignes = new ObservableCollection<string> { "" };  
            ConsigneItemsControl.ItemsSource = Consignes;
            consignes = Consignes;
        }

        private void AjouterConsigne_Click(object sender, RoutedEventArgs e)
        {
            if (Consignes.Count > 0)
            {
                Consignes.Add("");

            }
        }

        private void EnregistrerConsignes_Click(object sender, RoutedEventArgs e)
        {
            if (Consignes.Count > 0)
            {
                MessageBox.Show("Consigne ajoutée");
                this.Close();
            }
        }
    }
}
