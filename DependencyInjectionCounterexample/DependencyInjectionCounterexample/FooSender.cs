using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionCounterexample
{
    class FooSender
    {
        public void Send()
        {
            FooProcessor processor = new FooProcessor();
            IEnumerable<FooItem> foos = processor.ProcessFoos();
            var logger = new Logger();

            foreach (var foo in foos)
            {
                //Sending has a logging side effect
                logger.Log("Started sending a foo...");

                //Sending is expensive
                //zoom zoom the foos go over the wire somewhere
                Thread.Sleep(10000);

                //Sending has another logging side effect
                logger.Log("Sent a foo.");
            }
        }
    }
}
