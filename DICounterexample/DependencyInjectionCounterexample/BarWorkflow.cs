using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionCounterexample
{
    class BarWorkflow : IWorkflow
    {
        public void Run()
        {
            var repo = new ItemRepository();
            var items = repo.GetAll();
            var bars = items.Where(i => i.IsBar)
                            .Select(i => new BarItem(i));
            var logger = new ConsoleLogger();

            foreach (var bar in bars)
            {
                //Deleting has a logging side effect
                logger.Log("Started deleting a record because of bar...");

                //Deleting is expensive
                Thread.Sleep(10000);

                //Deleting has another logging side effect
                logger.Log("Deleted a record because of bar.");
            }
        }
    }
}
