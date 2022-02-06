using GameStoreAPI.GameData;
using GameStoreAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.GameData;

namespace Web_API
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
            //context.Database.Migrate();

            services.AddControllers();
            services.AddDbContextPool<Context>
                (options => options.UseNpgsql("Server=localhost;User ID=postgres;Password=1234;Database=postgres;"));

            services.AddSingleton<IGameData, MockGameData>();
            services.AddScoped<IGameData, SqlGameData>();

            services.AddSingleton<IGenreData, MoskGenreData>();
            services.AddScoped<IGenreData, SqlGenreData>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            if (!env.IsDevelopment()) 
            {
                app.UseStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
