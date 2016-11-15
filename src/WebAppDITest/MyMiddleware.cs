//using System.IO;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;

//namespace WebAppDITest
//{

//    /// <summary>
//    /// http://www.binaryintellect.net/articles/439edbad-fd51-4eaf-953a-5484941c7e8c.aspx
//    /// http://blog.dudak.me/2014/custom-middleware-with-dependency-injection-in-asp-net-core/
//    /// 
//    /// http://www.mikesdotnetting.com/article/269/asp-net-5-middleware-or-where-has-my-httpmodule-gone
//    /// 
//    /// </summary>
//    public class MyMiddleware
//    {           
//        private readonly RequestDelegate nextMiddleware;
//        private readonly IScriptManager _scriptManager;

//        RequestDelegate _next;

//        public MyMiddleware(RequestDelegate next, IScriptManager scriptManager)
//        {
//            _next = next;
//            _scriptManager = scriptManager;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            var cnt = _scriptManager.Scripts.Count;
//            using (var memoryStream = new MemoryStream())
//            {
//                var bodyStream = context.Response.Body;
//                context.Response.Body = memoryStream;

//                await _next(context);

//                var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
//                if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
//                {
//                    memoryStream.Seek(0, SeekOrigin.Begin);
//                    using (var streamReader = new StreamReader(memoryStream))
//                    {
//                        var responseBody = await streamReader.ReadToEndAsync();
//                        // update html
//                        StringBuilder sb = new StringBuilder();
//                        if (_scriptManager.Scripts.Count > 0)
//                        {
//                            foreach (var scriptRef in _scriptManager.Scripts)
//                            {
//                                sb.AppendLine(string.Format("<script src='{0}' ></script>", scriptRef));
//                            }
//                            if (sb.Length > 0)
//                            {
//                                responseBody = responseBody.Replace("</body>", sb + "</body>");
//                            }

//                        }



//                        using (var amendedBody = new MemoryStream())
//                        using (var streamWriter = new StreamWriter(amendedBody))
//                        {
//                            streamWriter.Write(responseBody);
//                            amendedBody.Seek(0, SeekOrigin.Begin);
//                            await amendedBody.CopyToAsync(bodyStream);
//                        }
//                    }
//                }
//            }
//        }
//    }
//}
