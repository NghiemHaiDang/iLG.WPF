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
    public class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is FONT_SIZE fontSizeEnum)
            {
                return (int)fontSizeEnum;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int size)
            {
                foreach (FONT_SIZE fontSizeEnum in Enum.GetValues(typeof(FONT_SIZE)))
                {
                    if ((int)fontSizeEnum == size)
                    {
                        return fontSizeEnum;
                    }
                }
            }
            return FONT_SIZE.LogoSize;
        }
    }
}
