﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionCounterexample
{
    class FooWorkflow : IWorkflow
    {
        public void Run()
        {
            FooSender sender = new FooSender();
            sender.Send();
        }
    }
}
