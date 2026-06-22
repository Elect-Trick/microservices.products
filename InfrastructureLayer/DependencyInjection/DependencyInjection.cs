using ApplicationLayer.ServiceContracts;
using InfrastructureLayer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InfrastructureLayer.DatabaseContext;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DomanLayer.RepositoryContracts;
using InfrastructureLayer.Repositories;

namespace InfrastructureLayer.DependencyInjection;
    
    public static class DependencyInjection
    {

    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {


        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        return services;
        
    }
    }
