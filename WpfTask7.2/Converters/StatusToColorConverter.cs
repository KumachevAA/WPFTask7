using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using WpfTask7._2.Models;



namespace WpfTask7._2.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Status status)
            {
                switch (status)
                {
                    case Status.Park:
                        return Brushes.Green;

                    case Status.Running:
                        return Brushes.Red;

                    default:
                        break;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Brush br)
            {
                return br == Brushes.Green ? Status.Park : Status.Running;
            }

            return null;
        }
    }
}
