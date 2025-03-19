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

namespace Gestion_RH.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour UpdateTache.xaml
    /// </summary>
    public partial class UpdateTache : Window
    {
        public UpdateTache(Tache task)
        {
            InitializeComponent();
        }
    }
}
