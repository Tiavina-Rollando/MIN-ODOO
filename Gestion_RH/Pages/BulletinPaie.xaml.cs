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
using Gestion_RH.Classes;

namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour BulletinPaie.xaml
    /// </summary>
    public partial class BulletinPaie : Page
    {
        public BulletinPaie(Employe emp)
        {
            InitializeComponent();
        }
    }
}
