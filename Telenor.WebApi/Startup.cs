using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telenor.Infrastructure;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Telenor.Business.Interfaces;
using Telenor.Business;
using Telenor.Dal.Interfaces;
using Telenor.Dal;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Telenor.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddDbContext<CatalogContext>(optionsAction: opt => opt.UseInMemoryDatabase())
                    .AddSwagger()
                    .AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver
                                                = new DefaultContractResolver());

            services.AddAutoMapper();
            Mapper.AssertConfigurationIsValid();
            services.AddTransientServices();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.EnsureDatabaseIsSeeded();

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                    context.Context.Response.Headers.Add("Expires", "-1");
                },
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "ProductPics")),
                RequestPath = "/ProductPics"
            });
        }
    }

    public static class CustomExtensionMethods
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "ProductCatalogueContainers - Telenor Catalog HTTP API",
                    Version = "v1",
                    Description = "The Telenor Product Catalog HTTP API.",
                    TermsOfService = "Telenor Terms Of Service"
                });
            });
            return services;
        }
        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRepositoryProvider, RepositoryProvider>();
            serviceCollection.AddTransient<IProductBl, ProductBl>();
            serviceCollection.AddTransient<IProductDal, ProductDal>();
        }
    }
}
