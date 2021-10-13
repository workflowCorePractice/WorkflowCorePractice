using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkFlowCoreDemo1
{
    public class Goodbye: StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("goodbye");
            return ExecutionResult.Next();
        }
    }
}
