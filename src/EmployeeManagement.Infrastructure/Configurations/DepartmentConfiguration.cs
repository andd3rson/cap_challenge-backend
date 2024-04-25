using EmployeeManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(pk => pk.Id);
        builder.Property(pk => pk.Id)
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Name)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.HasData(
            new Department(1, "Administração"),
            new Department(2, "Engenharia"),
            new Department(3, "Comercial"),
            new Department(4, "IT Desenvolvemento")
        );
    }
}