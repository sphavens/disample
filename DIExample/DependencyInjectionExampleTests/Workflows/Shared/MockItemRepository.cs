using DependencyInjectionExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionExampleTests
{
    class MockItemRepository : IItemRepository
    {
        int _timesRun = 0;

        //Returns known set of items
        public IEnumerable<Item> GetAll()
        {
            Interlocked.Increment(ref _timesRun);

            return new Item[]
		    {
			    new Item() {IsFoo = true, IsBar=false},
			    new Item() {IsFoo = false, IsBar=false},
			    new Item() {IsFoo = true, IsBar=true},
			    new Item() {IsFoo = false, IsBar=true}
		    };
        }


        public void Run()
        {
            Interlocked.Increment(ref _timesRun);
        }

        public int TimesRun
        {
            get
            {
                return Thread.VolatileRead(ref _timesRun);
            }
        }
    }
}
