using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkFlowCoreDemo1.InputDataToStep.Steps;

namespace WorkFlowCoreDemo1.InputDataToStep
{
    public class HelloWithDicNameWorkflow : IWorkflow<Dictionary<string, string>>
    {
        public string Id => "HelloWithDicNameWorkflow";

        public int Version => 1;


        public void Build(IWorkflowBuilder<Dictionary<string, string>> builder)
        {
            builder
                .StartWith(context => ExecutionResult.Next())
                .WaitFor("MyEvent", (data, context) => context.Workflow.Id, data => DateTime.Now)
                    .Output((step, data) => data.Add("Name", step.EventData.ToString()))
                .Then<HelloWithName>()
                    .Input(step => step.name, data => data["Name"])
                .Then<GoodbyeWithName>()
                    .Input(step => step.name, data => data["Name"])
                    .Then(context => { Console.WriteLine("the end"); });
        }
    }
}
