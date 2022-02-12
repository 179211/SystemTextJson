using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SystemTextJson
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
            //services.AddControllersWithViews()
            //    .AddJsonOptions(opt=> { 
            //    opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //    opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            //    opt.JsonSerializerOptions.AllowTrailingCommas = true;
            //    opt.JsonSerializerOptions.WriteIndented = true;
            //    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //});

            //services.Configure<JsonOptions>(options => {
            //    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            //    options.JsonSerializerOptions.AllowTrailingCommas = true;
            //    options.JsonSerializerOptions.WriteIndented = true;
            //    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //});

            //services.Configure<JsonSerializerOptions>(options => {
            //    options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //    options.PropertyNameCaseInsensitive = true;
            //    options.AllowTrailingCommas = true;
            //    options.WriteIndented = true;
            //    options.Converters.Add(new JsonStringEnumConverter ());
            //});

            services.AddSingleton<JsonSerializerOptions>(new JsonSerializerOptions(JsonSerializerDefaults.Web) {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
                WriteIndented = true,
                Converters = { 
                    new JsonStringEnumConverter(),
                    //new DateTimeConverter()
                }
            });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
