namespace EmployeeManagement.Domain.Entity;

public class Project : AuditableEntity
{
    public Project()
    {
        
    }
    public Project(string name, string details, string location)
    {
        Name = name;
        Details = details;
        Location = location;
    }
    
    public string Name { get; set; }
    public string Details { get; set; }
    public string Location { get; set; }
  
}