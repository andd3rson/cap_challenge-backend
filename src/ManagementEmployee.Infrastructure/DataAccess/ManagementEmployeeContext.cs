using ManagementEmployee.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ManagementEmployee.Infrastructure.DataAccess;

public class ManagementEmployeeContext : DbContext
{
    public ManagementEmployeeContext(DbContextOptions<ManagementEmployeeContext> opt)
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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManagementEmployeeContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}