using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerGenerator(this IServiceCollection services)
        {
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
    }
}
