namespace EmployeeManagement.Domain.Entity;

public class Department : AuditableEntity
{
    public Department(string name)
    {
        Name = name;
    }

    public Department()
    {
        Name = String.Empty;
    }

    public string Name { get; set; }
}