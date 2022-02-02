using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReservationPlatform.API.Services;
using OloPlatform.Repositories;
using OloPlatform.Services;

namespace OloPlatform
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
            services.AddSingleton<IReservationsRepository, ReservationsRepository>();
            services.AddSingleton<IReservationsService, ReservationsService>();
            services.AddSingleton<IRepositoryUtilities, RepositoryUtilities>();
            services.AddSingleton<IInventoryRepository, InventoryRepository>();
            services.AddSingleton<IInventoryService, InventoryService>();
            services.AddSingleton<ILogger, Logger>();
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
