using FluentValidation;

namespace EmployeeManagement.Application.Employee.Commands.CreateEmployee;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.Fullname)
            .NotNull()
            .Length(3, 20);

        RuleFor(x => x.CPF)
            .NotNull()
            .Length(3, 50);
        
        
        // RuleFor(x => x.BirthDate)
        //     .MustAsync(OverEighteen);
    }

    private async Task<bool> OverEighteen(DateTime birthDate, CancellationToken cancellationToken)
    {
        if (birthDate < DateTime.Now.AddDays(-18))
        {
            return false;
        }

        return true;
    }
}