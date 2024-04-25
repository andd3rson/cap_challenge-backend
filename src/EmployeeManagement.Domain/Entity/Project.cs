using EmployeeManagement.Domain.Common;

namespace EmployeeManagement.Domain.Entity;

public class Project : AuditableEntity
{
    public Project()
    { }
    public Project(string name, string details)
    {
        Name = name;
        Details = details;
    }
    
    public string Name { get; set; }
    public string Details { get; set; }
    public string ManagerName { get; set; }
}