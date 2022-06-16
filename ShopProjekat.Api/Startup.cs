using Implementation;
using Implementation.Emails;
using Implementation.Logging;
using Implementation.UseCases.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjekatAsp.Application.Emails;
using ProjekatAsp.Application.UseCases;
using ProjekatAsp.Application.UseCases.Commands;
using ShopProjekat.Api.Core;
using ShopProjekat.Api.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ShopProjekat.Api
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
            var settings = new AppSettings();

            Configuration.Bind(settings);

            services.AddHttpContextAccessor();

            //Sve iz klase ContainerExtensions kao extensions metode
            services.AddApplicationUser();
            services.AddSingleton(settings);
            services.AddJwt(settings);
            services.AddShopContext();
            services.AddUseCases();

            services.AddTransient<IUseCaseLogger>(x => new SpUseCaseLogger(settings.ConnString));
            services.AddTransient<UseCaseHandler>();

            services.AddTransient<IEmailSender>(x =>
                    new SmtpEmailSender(settings.EmailOptions.FromEmail,
                                        settings.EmailOptions.Password,
                                        settings.EmailOptions.Port,
                                        settings.EmailOptions.Host));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopProjekat.Api", Version = "v1" });

                //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopProjekat.Api v1"));
            }

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseStaticFiles();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
