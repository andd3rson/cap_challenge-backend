using EmployeeManagement.Domain.Common;

namespace EmployeeManagement.Domain.Entity;

public class Employee : AuditableEntity
{
    public Employee()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
    }

    public Employee(string firstName, string lastName, double salary, DateTime birthDate, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Salary = salary;
        BirthDate = birthDate;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public double Salary { get; set; }
    public DateTime BirthDate { get; set; }
    
    public int DepartmentId { get; set; }
    public IEnumerable<Project> Projects { get; set; }
    public Department Department { get; set; }
    
}