using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInjectionExample;

namespace DependencyInjectionExampleTests.Workflows.Bar
{
    [TestClass]
    public class BarWorkflowTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "repo")]
        public void NullRepo_Ctor_Throws()
        {
            IItemRepository repo = null;
            IRecordDeleter deleter = new MockRecordDeleter();
            var workflow = new BarWorkflow(repo, deleter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "deleter")]
        public void NullDeleter_Ctor_Throws()
        {
            IItemRepository repo = new MockItemRepository();
            IRecordDeleter deleter = null;
            var workflow = new BarWorkflow(repo, deleter);
        }

        [TestMethod]
        public void AllValid_Run_Success()
        {
            //I don't know what a proper set of unit tests would be for a given workflow, other than that it should exercise all code paths
            //and confirm that all specifications are met. This is just an example.
            var repo = new MockItemRepository();
            var deleter = new MockRecordDeleter();
            var workflow = new BarWorkflow(repo, deleter);

            workflow.Run();

            Assert.AreEqual(1, repo.TimesRun);
            Assert.AreEqual(2, deleter.GetDeletedBars().Count());
        }
    }
}
