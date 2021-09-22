using System;
using System.ComponentModel;

namespace WpfTask7._2.Models
{
    public enum Status
    {
        Park,
        Running
    }

    public class TrolleyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler StatusUpdated;

        private int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        private Status status;
        public Status Status
        {
            get => status;

            set
            {
                status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
                StatusUpdated?.Invoke(this, new EventArgs());
            }
        }
    }
}
