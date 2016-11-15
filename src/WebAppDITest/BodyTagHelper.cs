using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebAppDITest
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("body")]
    public class BodyTagHelper : TagHelper
    {
        private readonly IScriptManager _scriptManager;

        public BodyTagHelper(IScriptManager scriptManager)
        {
            _scriptManager = scriptManager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_scriptManager.Scripts.Count > 0)
            {
                var str = _scriptManager.Scripts.Count + " Items Found In ScriptManager";

                output.PostContent.SetHtmlContent("<b>" + str + "</b>");
            }

           
            // output.Content.SetContent(str);
            //output.SuppressOutput();
        }
    }
}
