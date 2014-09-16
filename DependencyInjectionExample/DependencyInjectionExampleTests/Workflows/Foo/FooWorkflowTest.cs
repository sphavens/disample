using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInjectionExample;
using System.Linq;

namespace DependencyInjectionExampleTests
{
    [TestClass]
    public class FooWorkflowTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "repo")]
        public void NullRepo_Ctor_Throws()
        {
            IItemRepository repo = null;
            IFooProcessor processor = new StubFooProcessor();
            IFooSender sender = new MockFooSender();
            var workflow = new FooWorkflow(repo, processor, sender);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "processor")]
        public void NullProcessor_Ctor_Throws()
        {
            IItemRepository repo = new MockItemRepository();
            IFooProcessor processor = null;
            IFooSender sender = new MockFooSender();
            var workflow = new FooWorkflow(repo, processor, sender);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "sender")]
        public void NullSender_Ctor_Throws()
        {
            IItemRepository repo = new MockItemRepository();
            IFooProcessor processor = new StubFooProcessor();
            IFooSender sender = null;
            var workflow = new FooWorkflow(repo, processor, sender);
        }

        [TestMethod]
        public void AllValid_Run_Success()
        {
            //I don't know what a proper set of unit tests would be for a given workflow, other than that it should exercise all code paths
            //and confirm that all specifications are met. This is just an example.
            var repo = new MockItemRepository();
            var processor = new StubFooProcessor();
            var sender = new MockFooSender();
            var workflow = new FooWorkflow(repo, processor, sender);

            workflow.Run();

            Assert.AreEqual(1, repo.TimesRun);
            Assert.AreEqual(2, sender.GetSentFoos().Count());
        }
    }
}
