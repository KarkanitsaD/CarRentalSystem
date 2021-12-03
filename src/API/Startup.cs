using API.Extensions;
using Business.Extensions;
using Business.Options;
using Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddCorsPolicy();

            services.AddDbContext<CarRentalSystemContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));

            services.Configure<JwtOptions>(Configuration.GetSection(JwtOptions.Jwt));

            services.AddPasswordHasher();
            services.AddAutoMapper(typeof(Startup))
                .AddBusinessMapper();


            services.AddRepositories();
            services.AddServices();
            services.AddJwtBearerAuthentication(Configuration.GetSection(JwtOptions.Jwt).Get<JwtOptions>());
            services.AddAuthorizationService();

            services.AddControllersWithCache();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(typeof(Startup).Assembly));
            services.AddSwaggerGenerator();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseErrorHandler();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseCors(CorsOptions.CorsOptions.WebApp);

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}