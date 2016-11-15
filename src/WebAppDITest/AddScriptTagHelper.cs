using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebAppDITest
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("AddScript")]
    public class AddScriptTagHelper : TagHelper
    {
        private readonly IScriptManager _scriptManager;

        public AddScriptTagHelper(IScriptManager scriptManager)
        {
            _scriptManager = scriptManager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //var script = "PrivateValue: " + _scriptManager.PrivateValue + " script-" + Guid.NewGuid() + " Count: " +
            //             _scriptManager.Scripts.Count;

            var scriptGuid = Guid.NewGuid().ToString("N");

            var script = "<script src='" + scriptGuid + ".js'></script>";
            _scriptManager.AddScript(script);


            output.Content.SetContent("<b>Suppress This Normally " + scriptGuid + "</b>");
            //output.SuppressOutput();
        }
    }
}
