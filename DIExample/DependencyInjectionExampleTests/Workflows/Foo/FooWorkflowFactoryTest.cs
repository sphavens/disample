using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInjectionExample;

namespace DependencyInjectionExampleTests.Workflows.Foo
{
    [TestClass]
    public class FooWorkflowFactoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "repo")]
        public void NullRepo_Ctor_Throws()
        {
            IItemRepository repo = null;
            IFooProcessor processor = new StubFooProcessor();
            IFooSender sender = new MockFooSender();
            var factory = new FooWorkflowFactory(repo, processor, sender);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "processor")]
        public void NullProcessor_Ctor_Throws()
        {
            IItemRepository repo = new MockItemRepository();
            IFooProcessor processor = null;
            IFooSender sender = new MockFooSender();
            var factory = new FooWorkflowFactory(repo, processor, sender);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "sender")]
        public void NullSender_Ctor_Throws()
        {
            IItemRepository repo = new MockItemRepository();
            IFooProcessor processor = new StubFooProcessor();
            IFooSender sender = null;
            var factory = new FooWorkflowFactory(repo, processor, sender);
        }

        [TestMethod]
        public void Create_ReturnsWorkflow()
        {
            IItemRepository repo = new MockItemRepository();
            IFooProcessor processor = new StubFooProcessor();
            IFooSender sender = new MockFooSender();
            var factory = new FooWorkflowFactory(repo, processor, sender);

            FooWorkflow workflow = factory.Create();
            Assert.IsNotNull(workflow);
        }
    }
}
