using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionCounterexample
{
    class FooWorkflow
    {
        public void Run()
        {
            FooSender processor = new FooSender();
            processor.Send();
        }
    }
}
