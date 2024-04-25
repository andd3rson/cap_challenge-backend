namespace EmployeeManagement.Application.Employee.Queries.GetEmployee;

public class GetEmployeeResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public double Salary { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    
}