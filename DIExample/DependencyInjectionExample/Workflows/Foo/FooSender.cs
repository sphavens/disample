using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    class FooSender : IFooSender
    {
        readonly ILogger _logger;

        public FooSender(ILogger logger)
        {
            _logger = logger;
        }

        public void Send(IEnumerable<FooItem> foos)
        {
            foreach (var foo in foos)
            {
                //Sending has a logging side effect
                _logger.Log("Started sending a foo...");
                
                //Sending is expensive.
                //zoom zoom the foos go over the wire somewhere
                Thread.Sleep(10000);

                //Sending has another logging side effect
                _logger.Log("Sent a foo.");
            }
        }
    }
}
