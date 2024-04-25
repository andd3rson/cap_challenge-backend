using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Common.Interfaces;

public interface IEmployeeManagementContext
{
    public DbSet<Domain.Entity.Department> Departments { get; set; }
    public Task<int> SaveChangeAsync(CancellationToken cancellationToken);
}