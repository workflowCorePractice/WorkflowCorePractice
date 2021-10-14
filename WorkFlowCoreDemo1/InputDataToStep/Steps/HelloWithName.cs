using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkFlowCoreDemo1.InputDataToStep.Steps
{
    public class HelloWithName: StepBody
    {
        public string name { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Hello, " + name);
            return ExecutionResult.Next();
        }
    }
}
