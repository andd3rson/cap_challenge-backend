using EmployeeManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(pk => pk.Id);
        builder.Property(pk => pk.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnType("varchar(20)")
            .IsRequired();
        builder.Property(p => p.Details)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(p => p.ManagerName)
            .HasColumnType("varchar(20)")
            .IsRequired();
       

    }
}