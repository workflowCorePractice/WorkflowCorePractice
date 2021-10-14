using System;
using System.Collections.Generic;
using System.Text;

namespace WorkFlowCoreDemo1.InputDictionary
{
    public class InputDictionaryData
    {
        public Dictionary<string, object> MyDic;
        public string name { get; set; }
        public InputDictionaryData()
        {
            MyDic = new Dictionary<string, object>();
        }

    }
}
