using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using SoEasyPlatform.Code;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoEasyPlatform
{
    public class Configures
    {
        public static void AddConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var wwwrootDirs = Directory.GetDirectories(env.WebRootPath).Select(dir => Path.GetFileName(dir));
            app.UseMiddleware<LowercaseUrlMiddleware>(wwwrootDirs,env);
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            new InitTable().Start();
        }
    }
}
