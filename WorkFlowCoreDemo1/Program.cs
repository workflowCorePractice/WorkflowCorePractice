using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using WorkflowCore.Interface;

namespace WorkFlowCoreDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //BasicDemo.FlowRun.Run();
            InputDataToStep.FlowRunWithName.Run();
            //InputDataToStep.FlowRunWithDicName.Run();
        }
        
    }
}
