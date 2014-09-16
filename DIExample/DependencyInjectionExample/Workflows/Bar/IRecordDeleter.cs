using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public interface IRecordDeleter
    {
        void DeleteRecords(IEnumerable<BarItem> bars);
    }
}
