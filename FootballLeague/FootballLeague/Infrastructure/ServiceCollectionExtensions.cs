using FootballLeague.Services.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace FootballLeague.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConventionalServices(this IServiceCollection services)
        {
            var serviceInteraceType = typeof(IService);
            var signletonInerfaceType = typeof(ISingletonService);
            var scopedInterfaceType = typeof(IScopedService);

            var types = serviceInteraceType
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (serviceInteraceType.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
                else if (signletonInerfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }
                else if (scopedInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
            }

            return services;
        }
    }
}
