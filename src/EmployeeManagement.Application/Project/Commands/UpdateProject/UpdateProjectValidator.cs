using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Application.Department.Commands.UpdateDepartment;
using FluentValidation;

namespace EmployeeManagement.Application.Project.Commands.UpdateProject;

public class UpdateProjectValidator : AbstractValidator<UpdateDepartmentCommand>
{
    private readonly IEmployeeManagementContext _context;
    public UpdateProjectValidator(IEmployeeManagementContext context)
    {
        _context = context;
       
    }
    
}