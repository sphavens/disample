using DependencyInjectionExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExampleTests.Workflows.Bar
{
    [TestClass]
    public class BarWorkflowFactoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "repo")]
        public void NullRepo_Ctor_Throws()
        {
            IItemRepository repo = null;
            IRecordDeleter deleter = new MockRecordDeleter();
            var factory = new BarWorkflowFactory(repo, deleter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "deleter")]
        public void NullDeleter_Ctor_Throws()
        {
            IItemRepository repo = new MockItemRepository();
            IRecordDeleter deleter = null;
            var factory = new BarWorkflowFactory(repo, deleter);
        }

        [TestMethod]
        public void Create_ReturnsWorkflow()
        {
            IItemRepository repo = new MockItemRepository();
            IRecordDeleter deleter = new MockRecordDeleter();
            var factory = new BarWorkflowFactory(repo, deleter);

            BarWorkflow workflow = factory.Create();
            Assert.IsNotNull(workflow);
        }
    }
}
