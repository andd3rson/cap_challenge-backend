namespace EmployeeManagement.Domain.Entity;

public class Employee : AuditableEntity
{
    public Employee()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
    }

    public Employee(string firstName, string lastName, double salary, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
        BirthDate = birthDate;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Salary { get; set; }
    public DateTime BirthDate { get; set; }
}