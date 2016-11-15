using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDITest
{
    public interface IScriptManager
    {
        void AddScript(string script);
        List<string> Scripts { get; }
        string PrivateValue { get; }
    }
    
}
