using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfTask7._2.Converters
{
    public class InputToBrushConverter : IValueConverter
    {
        public static int min = 2;
        public static int max = int.MaxValue;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                if (str == "")
                    return Brushes.White;

                if (int.TryParse(str, out int number))
                {
                    if (number >= min && number <= max)
                    {
                        return Brushes.Green;
                    }
                }
            }

            return Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
