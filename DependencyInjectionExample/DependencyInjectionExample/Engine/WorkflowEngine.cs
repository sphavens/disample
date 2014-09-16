using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public class WorkflowEngine : IWorkflowEngine
    {
        ILogger _logger;

        public WorkflowEngine(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            _logger = logger;
        }

        public void Start(IEnumerable<IWorkflow> workflows)
        {
            if (workflows == null)
            {
                throw new ArgumentNullException("workflows");
            }

            _logger.Log("Starting all workflows...");

            foreach (var workflow in workflows)
            {
                _logger.Log("Starting workflow...");

                workflow.Run();

                _logger.Log("Finished workflow.");
            }

            _logger.Log("Finished all workflows.");
        }
    }
}
