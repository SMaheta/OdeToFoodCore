using Microsoft.AspNet.FileProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodCore.Middleware
{
    public static class ApplicationbuilderExtension
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, ApplicationEnvironment env) 
        {
            IFileProvider provider  = new PhysicalFileProvider(Path.Combine(env.ApplicationBasePath,"node_modules"));
                //new PhysicalFileProvider(Path.Combine(env.ApplicationBasePath,"node_modules"));

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
           // options.FileProvider = provider;

            app.UseStaticFiles(options);
            return app;
        }
    }
}
