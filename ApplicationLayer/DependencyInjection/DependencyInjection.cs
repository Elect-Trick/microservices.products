using ApplicationLayer.DTOS;
using ApplicationLayer.Validators;
using DomanLayer.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {

            services.AddScoped<IValidator<ProductDTO>, ProductValidator>();
            return services;

        }
    }
}
