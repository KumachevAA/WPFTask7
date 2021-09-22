using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using WpfTask7._2.Models;
using WpfTask7._2.ViewModels;
using WpfTask7._2.Views;

namespace WpfTask7._2.Converters
{
    public class ModelToViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ICollection<TrolleyModel> trolleys)
            {
                return trolleys.Select(tr => new TrolleyView()
                {
                    DataContext = new TrolleyViewModel(tr)
                }).ToList();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
