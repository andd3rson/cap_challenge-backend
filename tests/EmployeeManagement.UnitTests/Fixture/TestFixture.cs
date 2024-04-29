using AutoMapper;
using EmployeeManagement.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore.Internal;

namespace EmployeeManagement.UnitTests.Fixture;

public class TestFixture : IDisposable
{
    // Setup 
    public TestFixture()
    {
        Context = DataAccessContextFixture.Create();
        Mapper = MapperFixture.Create();   
    }

    public EmployeeManagementContext Context { get; }
    public IMapper Mapper { get; }

 

    // Cleanup
    public void Dispose()
    {
        DataAccessContextFixture.Destroy(Context);
    }
}