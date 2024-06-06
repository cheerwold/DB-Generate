using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace SoEasyPlatform.Code
{
    public class LowercaseUrlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEnumerable<string> _wwwrootDirs;
        private readonly IWebHostEnvironment _env;
        private readonly string webRootPath;

        public LowercaseUrlMiddleware(RequestDelegate next, IEnumerable<string> wwwrootDirs, IWebHostEnvironment env)
        {
            _env = env;
            _wwwrootDirs = wwwrootDirs;
            _next = next;
            webRootPath = _env.WebRootPath;
        }

        public Task Invoke(HttpContext context)
        {
            var filePath = context.Request.Path.Value;
            //如果不是目录，则是文件
            if (!Directory.Exists(filePath) && Path.GetExtension(filePath).Length>0)
            {
                // 查找文件目录下，不区分大小写匹配的文件
                var realFilePath = Directory.GetFiles(Path.GetDirectoryName(Path.Join(webRootPath, filePath)), "*", SearchOption.TopDirectoryOnly)
                       .FirstOrDefault(f => Path.GetDirectoryName(f).Equals(Path.GetDirectoryName(Path.Join(webRootPath, filePath)), StringComparison.OrdinalIgnoreCase) && Path.GetFileName(f).Equals(Path.GetFileName(filePath), StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrWhiteSpace(realFilePath))
                {
                    context.Request.Path = realFilePath.Replace(webRootPath, "").Replace("\\", "/");
                }
            }
            return _next(context);
        }
    }
}
