using System;
using System.IO;
using System.Reflection;
using API.Extensions;
using Business.Options;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .AddJsonFile("jwtsettings.json")
                .Build();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));

            services.Configure<JwtOptions>(Configuration.GetSection(JwtOptions.Jwt));

            services.AddAutoMapper(typeof(Startup));
            services.AddRepositories();
            services.AddServices();
            services.AddJwtBearerAuthentication(Configuration.GetSection(JwtOptions.Jwt).Get<JwtOptions>());
            services.AddAuthorizationService();

            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CarRentalSystem API",
                    Description = "Web api to rent cars",
                    TermsOfService = new Uri("https://example.com/BestCarRentalSystem"),
                    Contact = new OpenApiContact
                    {
                        Name = "Dmitry Karkanitsa",
                        Email = "aakarkanica@gmail.com",
                        Url = new Uri("https://vk.com/dkarkanitsa")
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorHandler();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}