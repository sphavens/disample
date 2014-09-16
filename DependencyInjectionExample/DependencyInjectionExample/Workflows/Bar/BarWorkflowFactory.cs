using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public class BarWorkflowFactory
    {
        readonly IItemRepository _itemRepository;
        readonly IRecordDeleter _recordDeleter;

        public BarWorkflowFactory(IItemRepository repo, IRecordDeleter deleter)
        {
            if (repo == null)
            {
                throw new ArgumentNullException("repo");
            }
            if (deleter == null)
            {
                throw new ArgumentNullException("deleter");
            }
            _itemRepository = repo;
            _recordDeleter = deleter;
        }

        public BarWorkflow Create()
        {
            return new BarWorkflow(_itemRepository, _recordDeleter);
        }
    }
}
