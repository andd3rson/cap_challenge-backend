using EmployeeManagement.Application.Common.Interfaces;
using EmployeeManagement.Application.Department.Commands.UpdateDepartment;
using FluentValidation;

namespace EmployeeManagement.Application.Project.Commands.UpdateProject;

public class UpdateProjectValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectValidator(IEmployeeManagementContext context)
    {
        RuleFor(x => x.Name)
            .NotNull()
            .MaximumLength(50);

        RuleFor(x => x.Details)
            .NotNull();

        RuleFor(x => x.ManagerName)
            .NotNull();
    }
}