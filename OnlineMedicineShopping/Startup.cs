using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineMedicineShopping.BusinessLayer.Interfaces;
using OnlineMedicineShopping.BusinessLayer.Services;
using OnlineMedicineShopping.BusinessLayer.Services.Repository;
using OnlineMedicineShopping.DataLayer;

namespace OnlineMedicineShopping
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
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<Mongosettings>(Options =>
            {
                Options.Connection = Configuration.GetSection("MongoConnection:Connection").Value;
                Options.DatabaseName = Configuration.GetSection("MongoConnection:DatabaseName").Value;
            });
            services.AddScoped<IMongoDBContext, MongoDBContext>();
            services.AddScoped<IAdminMedicineRepository, AdminMedicineRepository>();
            services.AddScoped<IAdminMedicineServices, AdminMedicineServices>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IMedicineServices, MedicineServices>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CorsPolicy"); // use Cors poliy to use above of UseMvc
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
