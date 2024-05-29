using Domain.Abstractions;
using Domain.Products;
using Infrastructure.Persistence.EntityFramework;
using Infrastructure.Persistence.EntityFramework.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.ConfigureOptions<DatabaseOptionsSetup>();

            services.AddDbContext<ApplicationDbContext>((serviceProvider, dbContextOptionsBuilder) =>
            {
                DatabaseOptions dbOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

                dbContextOptionsBuilder.UseNpgsql(
                    $"Server={dbOptions.Server};Port={dbOptions.Port};Database={dbOptions.Name};User Id={dbOptions.User};Password={dbOptions.Password};");

                dbContextOptionsBuilder.EnableDetailedErrors(dbOptions.DetailedErrors);
                dbContextOptionsBuilder.EnableSensitiveDataLogging(dbOptions.SensitiveDataLogging);
            });

            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IProductRepository, EfProductRepository>();

            services.AddTransient<ProductFinder>();

            return services;
        }
    }
}
