using FluentValidation;

namespace EmployeeManagement.Application.Project.Commands.CreateProject;

public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectValidator()
    {
    }
}