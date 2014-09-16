using DependencyInjectionExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExampleTests.Workflows.Bar
{
    class MockRecordDeleter : IRecordDeleter
    {
        private List<BarItem> _deleted = new List<BarItem>();

        public void DeleteRecords(IEnumerable<BarItem> bars)
        {
            lock (_deleted)
            {
                _deleted.AddRange(bars);
            }
        }

        public IEnumerable<BarItem> GetDeletedBars()
        {
            lock (_deleted)
            {
                return _deleted;
            }
        }
    }
}
