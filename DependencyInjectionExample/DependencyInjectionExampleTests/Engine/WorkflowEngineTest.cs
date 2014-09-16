using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInjectionExample;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjectionExampleTests
{
    [TestClass]
    public class WorkflowEngineTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "logger")]
        public void NullLogger_Ctor_Throws()
        {
            ILogger logger = null;
            var engine = new WorkflowEngine(logger);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "workflows")]
        public void NullWorkflows_Start_Throws()
        {
            ILogger logger = new MockLogger();
            var engine = new WorkflowEngine(logger);

            IEnumerable<IWorkflow> workflows = null;
            engine.Start(workflows);
        }

        [TestMethod]
        public void ZeroWorkflows_Start_LogsNoWorkflows()
        {
            var logger = new MockLogger();
            var engine = new WorkflowEngine(logger);

            var workflows = new IWorkflow[]{};
            engine.Start(workflows);

            IEnumerable<string> expectedLogResult = new string[]
            {
                "Starting all workflows...",
                "Finished all workflows."
            };
            IEnumerable<string> actualLogResult = logger.GetLogContents();

            Assert.IsTrue(expectedLogResult.SequenceEqual(actualLogResult));
        }

        [TestMethod]
        public void OneWorkflow_Start_RunsAndLogsOneWorkflow()
        {
            var logger = new MockLogger();
            var engine = new WorkflowEngine(logger);

            var workflow = new MockWorkflow();
            var workflows = new MockWorkflow[] { workflow };
            engine.Start(workflows);

            IEnumerable<string> expectedLogResult = new string[]
            {
                "Starting all workflows...",
                "Starting workflow...",
                "Finished workflow.",
                "Finished all workflows."
            };
            IEnumerable<string> actualLogResult = logger.GetLogContents();

            Assert.IsTrue(expectedLogResult.SequenceEqual(actualLogResult));
            Assert.AreEqual(1, workflow.TimesRun);
        }

        [TestMethod]
        public void ThreeWorkflows_Start_RunsAndLogsThreeWorkflows()
        {
            var logger = new MockLogger();
            var engine = new WorkflowEngine(logger);

            var workflow1 = new MockWorkflow();
            var workflow2 = new MockWorkflow();
            var workflow3 = new MockWorkflow();
            var workflows = new MockWorkflow[] { workflow1, workflow2, workflow3 };

            engine.Start(workflows);

            var starting = "Starting workflow...";
            var finished = "Finished workflow.";

            IEnumerable<string> expectedLogResult = new string[]
            {
                "Starting all workflows...",
                starting,
                finished,
                starting,
                finished,
                starting,
                finished,
                "Finished all workflows."
            };
            IEnumerable<string> actualLogResult = logger.GetLogContents();

            Assert.IsTrue(expectedLogResult.SequenceEqual(actualLogResult));
            foreach (var wf in workflows)
            {
                Assert.AreEqual(1, wf.TimesRun);
            }
        }
    }
}
