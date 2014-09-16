using DependencyInjectionExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExampleTests
{
    class StubFooProcessor : IFooProcessor
    {
        public IEnumerable<FooItem> ProcessFoos(IEnumerable<Item> items)
        {
            //Cheap business logic that returns known result set

            var fakeOriginalItem = new Item(){ IsFoo = true };
            var fakeOriginalItem2 = new Item() { IsFoo = true }; 
            return new FooItem[] 
            {
                new FooItem(fakeOriginalItem),
                new FooItem(fakeOriginalItem2)
            };
        }
    }
}
