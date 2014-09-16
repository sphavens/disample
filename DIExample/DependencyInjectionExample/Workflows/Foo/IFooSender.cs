using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public interface IFooSender
    {
        void Send(IEnumerable<FooItem> foos);
    }
}
