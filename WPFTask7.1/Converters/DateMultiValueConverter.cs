using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFTask7._1.Converters
{
    public class DateMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values?.Length != 3)
                return null;

            if (values[0] is int day &&
                values[1] is int month &&
                values[2] is int year)
            {
                try
                {
                    DateTime time = new DateTime(year, month, day);
                    return time.ToLongDateString();
                }
                catch (Exception)
                {
                    return "Недопустимая дата";
                }
            }
            else
            {
                return "Нечисловые значения";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value is DateTime dt)
            {
                return new object[] { dt.Day, dt.Month, dt.Year };
            }
            else
            {
                return null;
            }
        }
    }
}
