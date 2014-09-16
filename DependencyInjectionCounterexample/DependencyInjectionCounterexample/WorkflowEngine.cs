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
            var logger = new Logger();

            logger.Log("Starting all workflows...");

            logger.Log("Starting workflow...");
            var fooWorkflow = new FooWorkflow();
            fooWorkflow.Run();
            logger.Log("Finished workflow");

            logger.Log("Starting workflow...");
            var barWorkflow = new BarWorkflow();
            barWorkflow.Run();
            logger.Log("Finished workflow");

            logger.Log("Finished all workflows.");

        }
    }
}
