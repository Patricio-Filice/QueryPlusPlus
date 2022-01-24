using QueryPlusPlus.Domain.Repository.Entities;
using QueryPlusPlus.Domain.Repository.Interfaces;
using QueryPlusPlus.Domain.Repository.Repositories;
using QueryPlusPlus.Domain.Utils.Gadgets;
using QueryPlusPlus.Domain.Utils.Interfaces;
using System.Reflection;

namespace QueryPlusPlus.Dependencies
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencies(this IServiceCollection serviceCollection, params Assembly[] assemblies)
        {
            serviceCollection.AddAutoMapper(assemblies);
            serviceCollection.AddScoped<IReadOnlyRepository<Product>, OnMemoryProductoReadOnlyRepository>();
            serviceCollection.AddScoped<IMapper, AutoMapperWrapper>();
        }
    }
}
