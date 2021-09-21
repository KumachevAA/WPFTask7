using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfTask7._2.Commands;
using WpfTask7._2.Models;

namespace WpfTask7._2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool TrolleyNotCreated => Trolleys.Count == 0;

        public ObservableCollection<TrolleyModel> Trolleys { get; } = new ObservableCollection<TrolleyModel>();

        public ICommand CreateTrolleys => new CreateTrolleysCommand(Trolleys);

        public MainViewModel()
        {
            Trolleys.CollectionChanged += (a, b) =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TrolleyNotCreated)));
            };
        }
    }
}
