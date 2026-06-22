using DomanLayer.RepositoryContracts;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
           
            return services;

        }
    }
}
