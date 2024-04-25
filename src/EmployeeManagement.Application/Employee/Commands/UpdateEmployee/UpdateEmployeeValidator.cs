using EmployeeManagement.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Department.Commands.UpdateDepartment;

public class UpdateEmployeeValidator : AbstractValidator<UpdateDepartmentCommand>
{
    private readonly IEmployeeManagementContext _context;
    public UpdateEmployeeValidator(IEmployeeManagementContext context)
    {
        _context = context;
        RuleFor(x => x.Id)
            .MustAsync(IfExists).WithMessage("Something went wrong.");
    }

    private async Task<bool> IfExists(int id, CancellationToken cancellationToken)
    {
        return (await _context.Departments.AnyAsync(x => x.Id == id, cancellationToken));
    }
}