using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public class FooWorkflowFactory
    {
        readonly IItemRepository _itemRepository;
        readonly IFooProcessor _processor;
        readonly IFooSender _sender;

        public FooWorkflowFactory(IItemRepository repo, IFooProcessor processor, IFooSender sender)
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

        public FooWorkflow Create()
        {
            return new FooWorkflow(_itemRepository, _processor, _sender);
        }
    }
}
