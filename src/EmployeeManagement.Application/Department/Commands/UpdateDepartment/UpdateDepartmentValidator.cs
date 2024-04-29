using EmployeeManagement.Application.Common.Interfaces;
using FluentValidation;

namespace EmployeeManagement.Application.Department.Commands.UpdateDepartment;

public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentCommand>
{
  
    public UpdateDepartmentValidator(IEmployeeManagementContext context)
    {
        
        RuleFor(x => x.Name)
            .MaximumLength(50)
            .NotEmpty();
    }
  
}