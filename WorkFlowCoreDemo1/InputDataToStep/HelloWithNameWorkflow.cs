using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkFlowCoreDemo1.InputDataToStep.Steps;

namespace WorkFlowCoreDemo1.InputDataToStep
{
    class HelloWithNameWorkflow : IWorkflow<MyNameClass>
    {
        public string Id => "HelloWithNameWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<MyNameClass> builder)
        {
            builder
                .StartWith(context => ExecutionResult.Next())
                //WaitFor 定义了一个事件，事件名称是"MyEvent"
                //这个事件的输出是：将事件接收的外部参数step.EventData 传递给了流程中的MyName属性
                .WaitFor("MyEvent", (data, context) => context.Workflow.Id, data => DateTime.Now)
                    .Output(data => data.MyName, step => step.EventData)
                .Then<HelloWithName>()
                    .Input(step => step.name, data => data.MyName)
                .Then<GoodbyeWithName>()
                    .Input(step => step.name, data => data.MyName);
        }
    }
}
