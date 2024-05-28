using Domain.Products;
using Infrastructure.Persistence.InMemory;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, InMemoryProductRepository>();
            services.AddTransient<ProductFinder>();

            return services;
        }
    }
}
