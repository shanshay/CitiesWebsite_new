using CitiesWebsite_new.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesWebsite_new
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddRazorPages();
            services.AddSingleton<ICityProvider, CityProvider>();
            services.AddSingleton<ICityFormatter, CityFormatter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();

            //app.MapControllerRoute(
             //   name: "default",
              //  pattern: "{controller=Home}/{action=Index}/{id?}");

           // app.UseEndpoints(endpoints =>
           // {
           //     endpoints.MapRazorPages();
           // });
            app.UseEndpoints(endpoints =>
            {
                // определение маршрутов
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=City}/{action=ShowCities}/{id?}");
            });

        }
    }
}
