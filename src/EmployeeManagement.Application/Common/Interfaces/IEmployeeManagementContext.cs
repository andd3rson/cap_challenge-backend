using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Common.Interfaces;

public interface IEmployeeManagementContext
{
    public DbSet<Domain.Entity.Department> Departments { get; set; }
    public DbSet<Domain.Entity.Employee> Employees { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}