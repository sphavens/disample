﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionCounterexample
{
    class Program
    {
        //Non-modular application
        //No use of dependency injection and only two interfaces (IEnumerable and IWorkflow)

        static void Main(string[] args)
        {
            var engine = new WorkflowEngine();
            engine.Start();

            EndProgram();
        }

        private static void EndProgram()
        {
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }
    }
}
