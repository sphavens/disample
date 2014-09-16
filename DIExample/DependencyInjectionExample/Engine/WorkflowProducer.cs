using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    class WorkflowProducer : IWorkflowProducer
    {
        readonly FooWorkflowFactory _fooWorkflowFactory;
        readonly BarWorkflowFactory _barWorkflowFactory;

        public WorkflowProducer(FooWorkflowFactory fooWorkflowFactory, BarWorkflowFactory barWorkflowFactory)
        {
            if (fooWorkflowFactory == null)
            {
                throw new ArgumentNullException("fooWorkflowFactory");
            }
            if (barWorkflowFactory == null)
            {
                throw new ArgumentNullException("barWorkflowFactory");
            }

            _fooWorkflowFactory = fooWorkflowFactory;
            _barWorkflowFactory = barWorkflowFactory;
        }

        public IEnumerable<IWorkflow> GetWorkflows()
        {
            //In practice, this probably loads from a config or a database.
            return new IWorkflow[]
		    {
			    _fooWorkflowFactory.Create(),
			    _barWorkflowFactory.Create()
		    };
        }
    }
}
