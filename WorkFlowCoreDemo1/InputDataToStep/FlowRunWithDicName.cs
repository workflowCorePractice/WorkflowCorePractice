using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;


namespace WorkFlowCoreDemo1.InputDataToStep
{
    public class FlowRunWithDicName
    {
        public static void Run()
        {
            IServiceProvider serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<HelloWithDicNameWorkflow, Dictionary<string, string>>();
            host.Start();

            var initalData = new Dictionary<string, string>();
            var workflowId = host.StartWorkflow("HelloWithDicNameWorkflow", 1, initalData).Result;

            Console.WriteLine("please input your name(dictionary test):");
            string value = Console.ReadLine();
            host.PublishEvent("MyEvent", workflowId, value);

            Console.ReadLine();
            foreach(var key in initalData.Keys)
            {
                Console.WriteLine(key + ":" + initalData[key]);
            }
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
