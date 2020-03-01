using FlightManager.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightManager.Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection PopulateGlobalConstnts(this IServiceCollection services, IConfiguration configuration)
        {
            GlobalConstants.EmailCredentials.Email = configuration["Email:Username"];

            return services;
        }
    }
}
