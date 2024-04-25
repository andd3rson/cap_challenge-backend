using EmployeeManagement.Domain.Common;

namespace EmployeeManagement.Domain.Entity;

public class Department : AuditableEntity
{
    public Department(string name)
    {
        Name = name;
    }
    public Department(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Department()
    {
        Name = String.Empty;
    }

    public string Name { get; set; }
}