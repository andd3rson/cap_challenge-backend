using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IEmployeeManagementContext>(provider =>
            provider.GetService<EmployeeManagementContext>()!);
        
        services.AddDbContext<EmployeeManagementContext>(x
            => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("EmployeeManagement.Api")));

        return services;
    }
}