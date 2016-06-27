using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OdeToFoodCore.Services;
using Microsoft.AspNetCore.Routing;
using OdeToFoodCore.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace OdeToFoodCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(environment.ContentRootPath)
                          .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.AddEntityFramework()
            //        .AddSqlServer()
            //        .AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(Configuration["database:connection"].ToString()));

            //services.AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(Configuration["database:connection"].ToString()));

            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeeter, Greeter>();
            services.AddScoped<IRestaurantData,InMemoryRestaurantData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IGreeeter greeter, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRuntimeInfoPage("/info");

            app.UseFileServer();

          //  app.UseNodeModules();

            app.UseMvc(ConfigureRoutes);
        

            app.Run(async (context) => {
                var greetings = greeter.GetGreetings();
                await context.Response.WriteAsync(greetings);
            });
        }

        private void ConfigureRoutes(IRouteBuilder routebuilder)
        {
           routebuilder.MapRoute("Default",
                                    "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
