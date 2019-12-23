using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FootballLeague.Infrastructure
{
    public static class IdentityConfigurationExtensions
    {
        public static IServiceCollection IdentityOptionsConfiguration(this IServiceCollection services)
        {
            services
                .Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                });

            return services;
        }
    }
}
