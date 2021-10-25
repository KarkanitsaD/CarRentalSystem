using API.Extensions;
using Business;
using Data;
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
            services.Configure<JwtOptions>(Configuration.GetSection(JwtOptions.Jwt))
                .AddJwtTokenHandler()
                .AddJwtAuthentication(Configuration.GetSection(JwtOptions.Jwt).Get<JwtOptions>());

            services.AddDbContext<ApplicationContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));

            services.AddAutoMapper(typeof(Startup));
            services.AddRepositories();
            services.AddServices();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseErrorHandler();

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