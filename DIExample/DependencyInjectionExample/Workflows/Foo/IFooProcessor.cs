using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public interface IFooProcessor
    {
        IEnumerable<FooItem> ProcessFoos(IEnumerable<Item> items);
    }
}
