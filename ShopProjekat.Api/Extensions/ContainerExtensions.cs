
using ProjekatAsp.Application.UseCases.Commands;
using ProjekatAsp.Application.UseCases.Queries;
using ProjekatAsp.DataAccess;
using ProjekatAsp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using ShopProjekat.Api.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Implementation.UseCases.Commands;
using Implementation.Validators;
using ProjekatAsp.Application.Logging;
using Implementation.Logging;
using Implementation.UseCases.Queries.Ef;
using Newtonsoft.Json;

namespace ShopProjekat.Api.Extensions
{
    public static class ContainerExtensions
    {

        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<ShopDbContext>();
                var settings = x.GetService<AppSettings>();

                return new JwtManager(context, settings.JwtSettings);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IAddAuthorizedCommand, EfAddAuthorizedCommand>();
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IUpdateUserUseCaseCommand, EfUpdateUserUseCasesCommand>();
            services.AddTransient<IGetProductsQuery, EfGetProdcutsQuery>();
            services.AddTransient<IAddProductToCartCommand, EfAddProductToCartCommand>();
            services.AddTransient<IGetCartWithProductsQuery, EfGetCartWithProducts>();
            services.AddTransient<IAddCommentWithProductsCommand, EfAddCommentWithProductsCommand>();
            services.AddTransient<IGetCommentWithProductQuery, EfIGetCommentWithProductQuery>();


            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<UpdateUserUseCasesValidator>();
            services.AddTransient<CreateProductValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<CreateCommentValidator>();
        }

        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                //Pristup payload-u
                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonimousUser();
                }

                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
        }

        public static void AddShopContext(this IServiceCollection services)
        {
            services.AddTransient(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var conString = x.GetService<AppSettings>().ConnString;

                var options = optionsBuilder.Options;

                return new ShopDbContext(options);
            });
        }

    }
}
