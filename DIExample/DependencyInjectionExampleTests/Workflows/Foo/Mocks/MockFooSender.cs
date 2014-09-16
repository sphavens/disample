using DependencyInjectionExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExampleTests
{
    class MockFooSender : IFooSender
    {
        List<FooItem> _sent = new List<FooItem>();

        public void Send(IEnumerable<FooItem> foos)
        {
            lock (_sent)
            {
                _sent.AddRange(foos);
            }
        }

        public IEnumerable<FooItem> GetSentFoos()
        {
            lock (_sent)
            {
                return _sent;
            }
        }
    }
}
