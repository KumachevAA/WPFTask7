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

        private string trCount;
        public string TrolleyCount
        {
            get => trCount;

            set
            {
                trCount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TrolleyCount)));
            }
        }

        private DateTime parkCreated;
        public DateTime ParkCreated
        {
            get => parkCreated;
            set
            {
                parkCreated = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ParkCreated)));
            }
        }

        private string log;
        public string Log
        {
            get => log;
            set
            {
                log = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Log)));
            }
        }

        void UpdateLog(object sender, EventArgs e)
        {
            TrolleyModel trolley = sender as TrolleyModel;
            DateTime moment = DateTime.Now;

            Log += $"Троллейбус {trolley.Id} выехал в {moment}, на {moment - ParkCreated} позже открытия ({ParkCreated})" + Environment.NewLine;
        }

        public MainViewModel()
        {
            Trolleys.CollectionChanged += (a, b) =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TrolleyNotCreated)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Trolleys)));

                foreach (TrolleyModel model in b.NewItems)
                {
                    model.StatusUpdated += UpdateLog;
                }

                ParkCreated = DateTime.Now;
            };
        }
    }
}
