using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using Gestion_RH.Classes;
using Microsoft.EntityFrameworkCore;

namespace Gestion_RH.ViewModels
{
    public class ChoixEmployeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Employe> _listeEmployesCard;
        public ObservableCollection<Employe> ListeEmployesCard
        {
            get => _listeEmployesCard;
            set
            {
                _listeEmployesCard = value;
                OnPropertyChanged(nameof(ListeEmployesCard));
            }
        }

        public ChoixEmployeViewModel()
        {
            ChargerEmployesDepuisBDD();
        }

        private void ChargerEmployesDepuisBDD()
        {
            using (var db = new ApplicationDbContext())
            {
                ListeEmployesCard = new ObservableCollection<Employe>(db.Employes
                    .Include(p => p.Poste)
                    .Include(p => p.Poste.Departement)
                    .ToList());
            }
        }

        public static BitmapImage ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
                return null;

            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                return image;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}