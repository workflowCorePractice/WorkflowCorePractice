using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkFlowCoreDemo1.InputDataToStep.Steps
{
    public class GoodbyeWithName:StepBody
    {
        public string name { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine(name + ", goodbye ");
            return ExecutionResult.Next();
        }
    }
}
