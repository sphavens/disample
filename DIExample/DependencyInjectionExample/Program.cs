using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    class Program
    {
        static IWorkflowEngine _defaultWorkflowEngine;
        static IWorkflowProducer _defaultWorkflowProducer;

        static void Main(string[] args)
        {
            ComposeModules();

            IEnumerable<IWorkflow> workflows = _defaultWorkflowProducer.GetWorkflows();
            _defaultWorkflowEngine.Start(workflows);

            EndProgram();
        }

        private static void EndProgram()
        {
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }

        static void ComposeModules()
        {
            //Bootstrapping section
            //Wherein we select the modules this application will use.
            //This is referred to as the "composition root" of a modular application.
            //There are several ways of implementing it, but I'm doing the simple route of hard coding the modules.

            var defaultLogger = new ConsoleLogger();
            var defaultItemRepository = new ItemRepository();

            _defaultWorkflowEngine = new WorkflowEngine(defaultLogger);

            _defaultWorkflowProducer = new WorkflowProducer
                (
                    new FooWorkflowFactory
                        (
                            defaultItemRepository,
                            new FooProcessor(),
                            new FooSender(defaultLogger)
                        ),
                    new BarWorkflowFactory
                        (
                            defaultItemRepository,
                            new RecordDeleter(defaultLogger)
                        )
                );
        }
    }
}
