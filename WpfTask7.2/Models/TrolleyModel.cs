using System.ComponentModel;

namespace WpfTask7._2.Models
{
    public class TrolleyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

    }
}
