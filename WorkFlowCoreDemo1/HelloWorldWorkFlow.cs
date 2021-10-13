
using WorkflowCore.Interface;

namespace WorkFlowCoreDemo1
{
    public class HelloWorldWorkFlow : IWorkflow
    {
        // 定义一个工作流，其中包含两个步骤，helloworld and goodbye
        public string Id => "helloworld"; // 需要和host.StartWorkflow 第一个参数一致
        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<HelloWorld>()
                .Then<Goodbye>();
        }
    }
}
