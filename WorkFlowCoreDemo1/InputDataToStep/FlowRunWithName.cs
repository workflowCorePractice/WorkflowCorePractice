using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

namespace WorkFlowCoreDemo1.InputDataToStep
{
    class FlowRunWithName
    {
        public static void Run()
        {
            /**
             * 执行步骤：
             * 1.创建WorkflowHost的实例
             * 2.注册工作流（可以注册多个）
             * 3.启动host
             * 4.初始化需要传入工作流的数据
             * 5.启动工作流（可以启动多个）
             * 6.关闭host
             */
            IServiceProvider serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<HelloWithNameWorkflow, MyNameClass>();
            host.Start();

            
            var initalData = new MyNameClass();
            var workflowId = host.StartWorkflow("HelloWithNameWorkflow",1,initalData).Result;
            
            Console.WriteLine("input your name:");
            string value = Console.ReadLine();
            // parameters: eventname eventkey eventdata
            host.PublishEvent("MyEvent",workflowId,value);

            Console.ReadLine();
            host.Stop();
        }
        private static IServiceProvider ConfigureServices()
        {
            //setup dependency injection
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
