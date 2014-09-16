using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public class FooProcessor : IFooProcessor
    {
        //I had a hard time coming up with something representative of complex business logic 
        public IEnumerable<FooItem> ProcessFoos(IEnumerable<Item> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            //Processing the business logic is expensive
            Thread.Sleep(1000);
            return items.Where(item => item.IsFoo)
                        .Select(item => new FooItem(item));
        }
    }
}
