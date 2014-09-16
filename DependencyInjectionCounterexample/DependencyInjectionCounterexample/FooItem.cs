using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionCounterexample
{
    class FooItem
    {
        Item _originalItem;

        public FooItem(Item originalItem)
        {
            _originalItem = originalItem;
        }
    }
}
