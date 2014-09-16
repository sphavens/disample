using DependencyInjectionExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExampleTests
{
    internal class MockLogger : ILogger
    {
        private List<string> _logs = new List<string>();

        public void Log(string description)
        {
            lock (_logs)
            {
                _logs.Add(description);
            }
        }

        public IEnumerable<string> GetLogContents()
        {
            lock (_logs)
            {
                return _logs;
            }
        }
    }
}
