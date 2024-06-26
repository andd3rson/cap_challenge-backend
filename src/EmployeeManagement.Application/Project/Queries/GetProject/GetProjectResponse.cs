using EmployeeManagement.Application.Employee.Queries.GetEmployee;

namespace EmployeeManagement.Application.Project.Queries.GetProject;

public class GetProjectResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public string ManagerName { get; set; }
    public List<GetEmployeeResponse> Employees { get; set; }
}