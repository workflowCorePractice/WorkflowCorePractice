using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

namespace WorkFlowCoreDemo1.BasicDemo
{
    public class FlowRun
    {
        // 在主程序中，创建WorkflowHost，注册并运行工作流
        public static void Run()
        {
            IServiceProvider serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>(); //获取WorkflowHost的实例
            host.RegisterWorkflow<HelloWorldWorkFlow>(); //注册工作流,可以注册多个
            host.Start(); // 启动Host
            host.StartWorkflow("helloworld", 1, null);//启动工作流，可以启动多个，并且是并行运行 // 第一个参数是workflow的id,需要和设定的一样！
            host.StartWorkflow("helloworld", 1, null);
            Thread.Sleep(1000);
            host.StartWorkflow("helloworld", 1, null);
            Console.ReadLine();
            host.Stop();// 关闭host，会终止所有流程
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
