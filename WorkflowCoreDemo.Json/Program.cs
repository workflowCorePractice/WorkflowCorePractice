using System;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Services.DefinitionStorage;

namespace WorkflowCoreDemo.Json
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            var loader = serviceProvider.GetService<IDefinitionLoader>();
            // 需要添加项目依赖 -> WorkFlowCoreDemo1
            var json = System.IO.File.ReadAllText("myflow.json");
            loader.LoadDefinition(json, Deserializers.Json);
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.Start();
            host.StartWorkflow("helloworld", 1, null); // 注意此处引用的工作流ID，要和引用的项目里面一致

            Console.ReadLine();
            host.Stop();

            
        }
        private static IServiceProvider ConfigureServices()
        {
            //setup dependency injection
            IServiceCollection services = new ServiceCollection();
            services.AddLogging();
            services.AddWorkflow();
            //这是新增加的服务
            services.AddWorkflowDSL();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
