using iLG.WPF.Presentation.Resources.InformationStyle;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace iLG.WPF.Presentation.Resources.Converter
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is COLOR color)
            {
                return System.Windows.Media.Color.FromArgb(
                    (byte)((int)color >> 24),
                    (byte)((int)color >> 16),
                    (byte)((int)color >> 8),
                    (byte)((int)color));
            }
            return System.Windows.Media.Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
