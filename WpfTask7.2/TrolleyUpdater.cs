using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfTask7._2.Models;

namespace WpfTask7._2
{
    public class TrolleyUpdater
    {
        public ICollection<TrolleyModel> Trolleys { get; }

        private async Task Live()
        {
            foreach (TrolleyModel model in Trolleys)
            {
                Thread.Sleep(2000);
                model.Status = Status.Running;
            }
        }

        public TrolleyUpdater(ICollection<TrolleyModel> trolleys)
        {
            Trolleys = trolleys;
            Task.Run(() => Live());
        }
    }
}
