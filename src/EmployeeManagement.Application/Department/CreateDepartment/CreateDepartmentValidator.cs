using EmployeeManagement.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Department.CreateDepartment;

public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommand>
{
    private readonly IEmployeeManagementContext _context;
    
    public CreateDepartmentValidator(IEmployeeManagementContext context)
    {
        _context = context;
        RuleFor(x => x.Name)
            .MaximumLength(50)
            .NotEmpty()
            .MustAsync(BeUniqueName);
    }

    private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _context.Departments
            .AnyAsync(x => 
                x.Name == name, cancellationToken);
    }
}