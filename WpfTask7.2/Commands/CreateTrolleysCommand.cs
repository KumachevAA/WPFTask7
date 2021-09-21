using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfTask7._2.Models;

namespace WpfTask7._2.Commands
{
    public class CreateTrolleysCommand : ICommand
    {
        private bool executed = false;

        private ObservableCollection<TrolleyModel> FillCollection { get; }

        public event EventHandler CanExecuteChanged;

        public CreateTrolleysCommand(ObservableCollection<TrolleyModel> fillCollection)
        {
            FillCollection = fillCollection;
        }

        public bool CanExecute(object parameter)
        {
            return !executed;
        }

        public void Execute(object parameter)
        {
            if (parameter is int count)
            {
                for (int i = 0; i < count; i++)
                {
                    FillCollection.Add(new TrolleyModel
                    {
                        Id = i
                    });
                }
            }

            executed = true;
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
