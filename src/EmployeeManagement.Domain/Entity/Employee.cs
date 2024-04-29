using EmployeeManagement.Domain.Common;

namespace EmployeeManagement.Domain.Entity;

public class Employee : AuditableEntity
{
    public Employee()
    {
        Fullname = String.Empty;
        CPF = String.Empty;
    }

    public Employee(string fullname, string cpf, double salary, DateTime birthDate, string email)
    {
        Fullname = fullname;
        CPF = cpf;
        Email = email;
        Salary = salary;
        BirthDate = birthDate;
    }

    public string Fullname { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public double Salary { get; set; }
    public DateTime BirthDate { get; set; }
    
    public int DepartmentId { get; set; }
    public IEnumerable<Project> Projects { get; set; }
    public Department Department { get; set; }
    
}