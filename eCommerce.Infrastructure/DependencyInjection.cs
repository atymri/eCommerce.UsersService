using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Infrastructure.DatabaseContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}
