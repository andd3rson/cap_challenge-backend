using EmployeeManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(pk => pk.Id);
        builder.Property(pk => pk.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(p => p.FirstName)
            .HasColumnType("varchar(20)")
            .IsRequired();
        builder.Property(p => p.LastName)
            .HasColumnType("varchar(20)")
            .IsRequired();
        
        
        
    }
}