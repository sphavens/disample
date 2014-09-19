using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionCounterexample
{
    class WorkflowEngine
    {
        public void Start()
        {
            var logger = new ConsoleLogger();

            logger.Log("Starting all workflows...");

            var workflowProducer = new WorkflowProducer();
            var workflows = workflowProducer.GetWorkflows();

            foreach (var workflow in workflows)
            {
                logger.Log("Starting workflow...");
                workflow.Run();
                logger.Log("Finished workflow");
            }

            logger.Log("Finished all workflows.");
        }
    }
}
