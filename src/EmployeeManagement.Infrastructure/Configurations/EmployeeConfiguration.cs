using EmployeeManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("tb_employee");
        builder.HasKey(pk => pk.Id);
        builder.Property(pk => pk.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Fullname)
            .HasColumnType("varchar(50)")
            .IsRequired();
        builder.Property(p => p.CPF)
            .HasColumnType("varchar(20)")
            .IsRequired();
            
        // n:n relationship
        builder.HasMany(x => x.Projects)
            .WithMany(x => x.Employees)
            .UsingEntity<EmployeeProject>(
            "tb_employee-project",
                e => e.HasOne<Project>().WithMany().HasForeignKey(fk => fk.ProjectId),
                p => p.HasOne<Employee>().WithMany().HasForeignKey(fk => fk.EmployeeId)
            );
        // 1:n relationship
        builder.HasOne(x => x.Department)
            .WithMany(x => x.Employees)
            .HasForeignKey(fk => fk.DepartmentId);
    }
}