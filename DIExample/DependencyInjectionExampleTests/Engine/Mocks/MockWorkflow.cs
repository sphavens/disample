using DependencyInjectionExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionExampleTests
{
    class MockWorkflow : IWorkflow
    {
        int _timesRun = 0;

        public void Run()
        {
            Interlocked.Increment(ref _timesRun);
        }

        public int TimesRun
        {
            get
            {
                return Thread.VolatileRead(ref _timesRun);
            }
        }
    }
}
