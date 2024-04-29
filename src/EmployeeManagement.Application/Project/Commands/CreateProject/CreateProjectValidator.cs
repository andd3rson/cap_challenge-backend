using FluentValidation;

namespace EmployeeManagement.Application.Project.Commands.CreateProject;

public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectValidator()
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