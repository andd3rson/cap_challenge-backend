using EmployeeManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
 {
  public void Configure(EntityTypeBuilder<Department> builder)
  {
  
  }
 }