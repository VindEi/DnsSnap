using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace DnsSnap.Style
{
    public class ColorConvert : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string colorString)
            {
                try
                {
                    Color color = (Color)ColorConverter.ConvertFromString(colorString);
                    return color;
                }
                catch (Exception ex)
                {
                    return DependencyProperty.UnsetValue;
                }
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
