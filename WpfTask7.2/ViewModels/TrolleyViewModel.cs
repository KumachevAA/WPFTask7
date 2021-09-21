using WpfTask7._2.Models;

namespace WpfTask7._2.ViewModels
{
    public class TrolleyViewModel
    {
        public TrolleyModel Model { get; }

        public TrolleyViewModel(TrolleyModel model)
        {
            Model = model;
        }
    }
}
