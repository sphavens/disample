using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    class RecordDeleter : IRecordDeleter
    {
        readonly ILogger _logger;

        public RecordDeleter(ILogger logger)
        {
            _logger = logger;
        }

        public void DeleteRecords(IEnumerable<BarItem> bars)
        {
            foreach (var bar in bars)
            {
                //Deleting has a logging side effect
                _logger.Log("Started deleting a record because of bar...");

                //Deleting is expensive
                Thread.Sleep(10000);

                //Deleting has another logging side effect
                _logger.Log("Deleted a record because of bar.");
            }
        }
    }
}
