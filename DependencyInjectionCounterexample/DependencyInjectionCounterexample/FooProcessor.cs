using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionCounterexample
{
    class FooProcessor
    {
        //I had a hard time coming up with something representative of complex business logic 
        public IEnumerable<FooItem> ProcessFoos()
        {
            ItemRepository itemRepository = new ItemRepository();
            IEnumerable<Item> items = itemRepository.GetAll();

            //Processing the business logic is expensive
            Thread.Sleep(1000);
            return items.Where(item => item.IsFoo)
                        .Select(item => new FooItem(item));
        }
    }
}
