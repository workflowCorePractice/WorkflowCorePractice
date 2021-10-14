using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;

namespace WorkFlowCoreDemo1.InputDictionary
{
    public class InputDicWorkflow : IWorkflow<InputDictionaryData>
    {
        public string Id => "InputDicWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<InputDictionaryData> builder)
        {
            throw new NotImplementedException();
        }


    }
}
