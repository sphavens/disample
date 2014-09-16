using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public class BarItem
    {
        Item _originalItem;

        public BarItem(Item originalItem)
        {
            _originalItem = originalItem;
        }
    }
}
