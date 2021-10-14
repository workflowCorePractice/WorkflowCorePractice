using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

namespace WorkFlowCoreDemo1.InputDictionary
{
    public class InputDicFlowRun
    {
        public static void Run()
        {
            IServiceProvider serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
            
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
