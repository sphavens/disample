using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public class BarWorkflow : IWorkflow
    {
        readonly IItemRepository _itemRepository;
        readonly IRecordDeleter _recordDeleter;

        public BarWorkflow(IItemRepository repo, IRecordDeleter deleter)
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

        public void Run()
        {
            var items = _itemRepository.GetAll();
            var bars = items.Where(i => i.IsBar)
                            .Select(i => new BarItem(i));
            _recordDeleter.DeleteRecords(bars);
        }
    }
}
