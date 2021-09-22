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
        Random rng;

        private Task Ride(TrolleyModel trolley)
        {
            Thread.Sleep(10000);
            trolley.Status = Status.Park;
            return Task.CompletedTask;
        }

        private Task Live()
        {
            while (true)
            {
                Thread.Sleep(rng.Next(100, 1000));

                TrolleyModel[] parked = Trolleys.Where(tr => tr.Status == Status.Park).ToArray();

                if (!parked.Any())
                    continue;

                var random = parked[rng.Next(parked.Length)];
                random.Status = Status.Running;
                Task.Run(async () => await Ride(random));
            }
        }

        public TrolleyUpdater(ICollection<TrolleyModel> trolleys)
        {
            Trolleys = trolleys;
            rng = new Random();
            Task.Run(async() => await Live());
        }
    }
}
