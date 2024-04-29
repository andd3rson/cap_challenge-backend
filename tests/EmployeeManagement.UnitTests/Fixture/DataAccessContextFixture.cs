using EmployeeManagement.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.UnitTests.Fixture;

public class DataAccessContextFixture
{
    public static EmployeeManagementContext Create()
    {
        var options = new DbContextOptionsBuilder<EmployeeManagementContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    
        var context = new EmployeeManagementContext(
            options);
        return context;
    }

    public static void Destroy(EmployeeManagementContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}