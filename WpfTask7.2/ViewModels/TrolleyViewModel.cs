using System.ComponentModel;
using WpfTask7._2.Models;

namespace WpfTask7._2.ViewModels
{
    public class TrolleyViewModel : INotifyPropertyChanged
    {
        public TrolleyModel Model { get; }

        public TrolleyViewModel(TrolleyModel model)
        {
            Model = model;
            Model.StatusUpdated += Model_StatusUpdated;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Model_StatusUpdated(object sender, System.EventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Model)));
        }

        public TrolleyViewModel() : this(new TrolleyModel()
        {
            Id = 1,
            Status = Status.Park
        })
        {

        }
    }
}
