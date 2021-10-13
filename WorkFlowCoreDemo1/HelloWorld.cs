using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkFlowCoreDemo1
{
    public class HelloWorld:StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("helloworld");
            return ExecutionResult.Next();
        }
    }
}
