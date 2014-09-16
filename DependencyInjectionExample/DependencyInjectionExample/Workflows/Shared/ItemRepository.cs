using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    class ItemRepository : IItemRepository
    {
        public IEnumerable<Item> GetAll()
        {
            //in real world, maybe get from database instead
            //simulate with sleep
            System.Threading.Thread.Sleep(1000);
            return new Item[]
		    {
			    new Item() {IsFoo = true},
			    new Item() {IsFoo = false},
			    new Item() {IsFoo = true},
			    new Item() {IsFoo = false},
			    new Item() {IsFoo = true},
			    new Item() {IsFoo = false, IsBar=true},
			    new Item() {IsFoo = true, IsBar=true},
			    new Item() {IsFoo = false, IsBar=true},
			    new Item() {IsFoo = true, IsBar=true},
			    new Item() {IsFoo = false, IsBar=true}
		    };
        }
    }
}
