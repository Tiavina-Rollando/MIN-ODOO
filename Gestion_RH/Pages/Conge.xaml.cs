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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestion_RH.Pages
{
    /// <summary>
    /// Logique d'interaction pour Conge.xaml
    /// </summary>
    public partial class Conge : Page
    {
        public Conge()
        {
            InitializeComponent();
            ((Storyboard)this.Resources["HideNotificationPanel"]).Completed += (s, e) =>
            {
                NotificationPanel.Visibility = Visibility.Collapsed;
            };
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Accueil()); // Naviguer vers la page d'accueil
        }
        private void Calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (calendar?.SelectedDate != null)
            {
                MessageBox.Show(calendar.SelectedDate.Value.ToShortDateString());
            }
        }
        private void BtnNotifications_Click(object sender, RoutedEventArgs e)
        {
            NotificationPanel.Visibility = Visibility.Visible;
            var storyboard = (Storyboard)this.Resources["ShowNotificationPanel"];
            storyboard.Begin();

        }
        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            var hide = (Storyboard)this.Resources["HideNotificationPanel"];
            hide.Begin();
        }

    }
}
