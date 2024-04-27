using EmployeeManagement.Domain.Common;

namespace EmployeeManagement.Domain.Entity;

public class Project : AuditableEntity
{
    public Project()
    {
    }

    public Project(string name, string details, string managerName)
    {
        Name = name;
        Details = details;
        ManagerName = managerName;
    }

    public string Name { get; set; }
    public string Details { get; set; }
    public string ManagerName { get; set; }
    
    public IEnumerable<Employee> Employees { get; set; }
}