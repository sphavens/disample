using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public class FooWorkflow : IWorkflow
    {
        readonly IItemRepository _itemRepository;
        readonly IFooProcessor _processor;
        readonly IFooSender _sender;

        //A large number of dependencies can indicate that the class is trying to do too much.
        //This is probably fine, but if the workflow becomes much longer, and introduces a lot
        //more dependencies, we may want to refactor.
        //As Mark Seeman says, "Constructor injection makes Single Responsibility Principle violations
        //glaringly obvious."
        public FooWorkflow(IItemRepository repo, IFooProcessor processor, IFooSender sender)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo");
            }
            if (processor == null)
            {
                throw new ArgumentNullException("processor");
            }
            if (sender == null)
            {
                throw new ArgumentNullException("sender");
            }

            _itemRepository = repo;
            _processor = processor;
            _sender = sender;
        }

        public void Run()
        {
            IEnumerable<Item> items = _itemRepository.GetAll();
            IEnumerable<FooItem> foos = _processor.ProcessFoos(items);
            _sender.Send(foos);
        }
    }
}
