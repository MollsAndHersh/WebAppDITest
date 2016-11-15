using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDITest
{
    public class ScriptManager : IScriptManager
    {
        public ScriptManager()
        {
            _scripts = new List<string>();
            PrivateValue = "Private-" + Guid.NewGuid().ToString("N");
        }

        private readonly List<string> _scripts;

        public string PrivateValue { get; }

        public List<string> Scripts { get { return _scripts; } }

       
        public void AddScript(string scriptName)
        {
            if (Scripts.All(x => x != scriptName))
            {
                _scripts.Add(scriptName);
            }
        }
    }
}
