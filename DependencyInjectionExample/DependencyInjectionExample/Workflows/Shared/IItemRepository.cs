using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
    }
}
