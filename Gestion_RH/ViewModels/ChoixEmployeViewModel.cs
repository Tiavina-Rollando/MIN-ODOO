using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using Gestion_RH.Classes;
using Microsoft.EntityFrameworkCore;

namespace Gestion_RH.ViewModels  // Assure-toi que cet espace de noms est correct
{
    public class ChoixEmployeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Employe> _listeEmployes;
        public ObservableCollection<Employe> ListeEmployes
        {
            get => _listeEmployes;
            set
            {
                _listeEmployes = value;
                OnPropertyChanged(nameof(ListeEmployes));
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
                ListeEmployes = new ObservableCollection<Employe>(db.Employes
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