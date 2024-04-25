using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Common.Interfaces;

public interface IEmployeeManagementContext
{
    public DbSet<Domain.Entity.Department> Departments { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}