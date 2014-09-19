using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    class ConsoleLogger : ILogger
    {
        public void Log(string description)
        {
            Console.WriteLine(description);
        }
    }
}
