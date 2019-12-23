using FootballLeague.Controllers;
using FootballLeague.Data;
using FootballLeague.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace FootballLeague.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseControllerEndPoinst(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            return app;
        }

        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            return app;
        }

        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var dbContext = services.GetService<FootballDbContext>();

                await dbContext.Database.MigrateAsync();

                var roleManager = services.GetService<RoleManager<IdentityRole>>();

                var existingRole = await roleManager.RoleExistsAsync(ControllerConstants.AdministratorRole);

                if (!existingRole)
                {
                    var adminRole = new IdentityRole(ControllerConstants.AdministratorRole);
                    await roleManager.CreateAsync(adminRole);
                }

                var userManager = services.GetService<UserManager<User>>();

                var adminExist = await userManager.FindByEmailAsync(ControllerConstants.AdministratorEmail);

                if (adminExist == null)
                {
                    var adminUser = new User
                    {
                        UserName = ControllerConstants.AdministratorEmail,
                        Email = ControllerConstants.AdministratorEmail,
                        SecurityStamp = "RandomSecurityStamp"
                    };

                    await userManager.CreateAsync(adminUser, ControllerConstants.AdministratorPassword);

                    await userManager.AddToRoleAsync(adminUser, ControllerConstants.AdministratorRole);
                }

                var normalUserExists = await userManager.FindByEmailAsync(ControllerConstants.NormalUserEmail);

                if (normalUserExists == null)
                {
                    var user = new User
                    {
                        UserName = ControllerConstants.NormalUserEmail,
                        Email = ControllerConstants.NormalUserEmail,
                        SecurityStamp = "AnotherRandomSecurityStamp"
                    };

                    await userManager.CreateAsync(user, ControllerConstants.NormalUserPassword);
                }

                var team1 = await dbContext.Teams.FirstOrDefaultAsync(t => t.Name == "Chelsea");
                if(team1 == null)
                {
                    team1 = new Team { Name = "Chelsea", Nationality = "England" };
                    await dbContext.AddAsync(team1);
                }

                var team2 = await dbContext.Teams.FirstOrDefaultAsync(t => t.Name == "Arsenal");
                if (team2 == null)
                {
                    team2 = new Team { Name = "Arsenal", Nationality = "England" };
                    await dbContext.AddAsync(team2);
                }

                var team3 = await dbContext.Teams.FirstOrDefaultAsync(t => t.Name == "Liverpool");
                if (team3 == null)
                {
                    team3 = new Team { Name = "Liverpool", Nationality = "England" };
                    await dbContext.AddAsync(team3);
                }

                var team4 = await dbContext.Teams.FirstOrDefaultAsync(t => t.Name == "Everton");
                if (team4 == null)
                {
                    team4 = new Team { Name = "Everton", Nationality = "England" };
                    await dbContext.AddAsync(team4);
                }

                await dbContext.SaveChangesAsync();
            }

            return app;
        }

        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            return app.SeedDataAsync().GetAwaiter().GetResult();
        }
    }
}
