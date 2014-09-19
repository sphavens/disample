using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionCounterexample
{
    class WorkflowProducer
    {
        public IEnumerable<IWorkflow> GetWorkflows()
        {
            //In practice, this probably loads from a config or a database.
            return new IWorkflow[]
		    {
			    new FooWorkflow(),
			    new BarWorkflow()
		    };
        }
    }
}
