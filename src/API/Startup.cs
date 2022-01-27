using API.ApplicationOptions;
using API.Extensions;
using Business.Extensions;
using Business.Options;
using Business.SingleR.Hubs;
using Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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

            services.AddSignalR();
            services.AddControllersWithCache();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(typeof(Startup).Assembly));
            services.AddSwaggerGenerator();
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
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

            app.UseCors(CorsOptions.ApiCorsName);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<LocationHub>("/location");
            });
        }
    }
}