using EmployeeManagement.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<EmployeeManagementContext>(x
            => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("EmployeeManagement.Api")));
    }
}