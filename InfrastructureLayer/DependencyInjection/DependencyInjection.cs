using ApplicationLayer.ServiceContracts;
using InfrastructureLayer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InfrastructureLayer.DatabaseContext;

namespace InfrastructureLayer.DependencyInjection;
    
    public static class DependencyInjection
    {

    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration, DbContext dbContext)
        {
      
                
        services.AddScoped<IProductService, ProductService>();

            services.AddDbContext<EfDbContext>(options =>
           options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(EfDbContext).Assembly.FullName)
           )
       );
            return services;
        }
    }
