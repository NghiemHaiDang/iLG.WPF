using iLG.WPF.Presentation.Resources.InformationStyle;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace iLG.WPF.Presentation.Resources.Converter
{
    public class ColorBrushValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is COLOR color)
            {
                return new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, (byte)(((uint)color & 0xFF0000) >> 16), (byte)(((uint)color & 0x00FF00) >> 8), (byte)((uint)color & 0x0000FF)));
            }
            return System.Windows.Media.Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Windows.Media.Color color)
            {
                return (COLOR)(((uint)color.R << 16) | ((uint)color.G << 8) | (uint)color.B);
            }
            return (COLOR)0;
        }
    }
}
