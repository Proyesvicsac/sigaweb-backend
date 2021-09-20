using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace SIGA.ServiceApi.Module.Extensions
{
    public static class Injection
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration); 
            
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.Load("SIGA.Repository"))
                 .Where(x => x.Name.EndsWith("Repository"))
                 .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(Assembly.Load("SIGA.Logic"))
                .Where(x => x.Name.EndsWith("Logic"))
                .AsPublicImplementedInterfaces();

            return services;
        }
    }
}
