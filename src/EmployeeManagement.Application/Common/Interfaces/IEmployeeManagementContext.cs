using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Common.Interfaces;

public interface IEmployeeManagementContext
{
    public DbSet<Domain.Entity.Department> Departments { get; set; }
    public DbSet<Domain.Entity.Employee> Employees { get; set; }
    public DbSet<Domain.Entity.Project> Projects { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}