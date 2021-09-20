using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace SIGA.ServiceApi.Module.Extensions
{
    public static class Feature
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiSigaWeb";

            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder//.WithOrigins(configuration["Config:OriginCors"])
                                                                                .AllowAnyOrigin()
                                                                                        .AllowAnyHeader()
                                                                                        .AllowAnyMethod()));
            services.AddControllers();

            return services;
        }
    }
}
