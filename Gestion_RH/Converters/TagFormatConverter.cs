using System;
using System.Globalization;
using System.Windows.Data;

namespace Gestion_RH.Converters
{
    public class TagFormatConverter : IValueConverter
    {
        // Méthode Convert pour formater le Tag
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int id && parameter is string prefix)
            {
                return $"{prefix}|{id}"; // Formater le tag avec le prefix et l'ID
            }
            return null;
        }

        // Méthode ConvertBack, ici on ne la gère pas donc on retourne null
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
