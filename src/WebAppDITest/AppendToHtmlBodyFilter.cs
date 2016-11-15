using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppDITest
{
    public class AppendToHtmlBodyFilter : TypeFilterAttribute
    {
        private readonly IScriptManager _scriptManager;

        public AppendToHtmlBodyFilter():base(typeof(SampleActionFilterImpl))
        {
        }

        private class SampleActionFilterImpl : IResultFilter
        {
            private readonly IScriptManager _scriptManager;

            public SampleActionFilterImpl(IScriptManager scriptManager)
            {
                _scriptManager = scriptManager;
                //_logger = loggerFactory.CreateLogger<SampleActionFilterAttribute>();
            }

            public void OnResultExecuted(ResultExecutedContext context)
            {
                var cnt = _scriptManager.Scripts.Count;

                Stream originalStream = context.HttpContext.Response.Body;
                using (MemoryStream newStream = new MemoryStream())
                {
                    context.HttpContext.Response.Body = newStream;
                    context.HttpContext.Response.Body = originalStream;
                    newStream.Seek(0, SeekOrigin.Begin);
                    StreamReader reader = new StreamReader(newStream);

                    // this comes out to empty string.  Want data here
                    // and want way to push data back into response
                    var htmlData = reader.ReadToEnd();
                }
            }

            public void OnResultExecuting(ResultExecutingContext context)
            {
                var cnt = _scriptManager.Scripts.Count;
            }
        }
    }
}