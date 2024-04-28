using System.Reflection;
using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.DataAccess;

public class EmployeeManagementContext : DbContext, IEmployeeManagementContext
{
    public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> opt)
        : base(opt)
    { }

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
   

    public virtual DbSet<Project> Projects { get; set; }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var item in ChangeTracker.Entries<AuditableEntity>())
        {
            if (item.State == EntityState.Added)
            {
                item.Entity.CreatedAt = DateTime.UtcNow;
                item.Entity.UpdatedAt = DateTime.UtcNow;
            }

            if (item.State == EntityState.Modified)
            {
                item.Entity.UpdatedAt = DateTime.UtcNow;   
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Navigation(x => x.Department)
            .AutoInclude();
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeManagementContext).Assembly);
    }
}