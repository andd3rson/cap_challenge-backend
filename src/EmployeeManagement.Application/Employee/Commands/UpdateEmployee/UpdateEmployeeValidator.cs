using EmployeeManagement.Application.Common.Utils;
using FluentValidation;

namespace EmployeeManagement.Application.Employee.Commands.UpdateEmployee;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(x => x.Fullname)
            .NotNull()
            .Length(3, 50);

        RuleFor(x => x.CPF)
            .NotNull()
            .Must(ValidatorMethods.IfIsACpf)
            .Length(11);
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotNull();

        RuleFor(x => x.Salary)
            .NotNull();

        RuleFor(x => x.BirthDate)
            .NotNull();
    }
    
}