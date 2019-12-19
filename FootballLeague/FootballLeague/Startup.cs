using FootballLeague.Data;
using FootballLeague.Data.Models;
using FootballLeague.Infrastructure;
using FootballLeague.Services.Implementations;
using FootballLeague.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FootballLeague
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
            services.AddDbContext<FootballDbContext>(options => options
                        .UseSqlServer(Configuration.GetDefaultConnectionString()));

            services.AddIdentity<User, IdentityRole>()
                        .AddEntityFrameworkStores<FootballDbContext>()
                        .AddDefaultUI()
                        .AddDefaultTokenProviders();

            services.AddTransient<ITeamService, TeamService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDatabaseMigration();

            app.UseExceptionHandling(env);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseControllerEndPoinst();
        }
    }
}
