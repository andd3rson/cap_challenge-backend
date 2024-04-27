using EmployeeManagement.Application.Common.Interfaces;
using FluentValidation;

namespace EmployeeManagement.Application.Employee.Commands.UpdateEmployee;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
{
    private readonly IEmployeeManagementContext _context;
    public UpdateEmployeeValidator(IEmployeeManagementContext context)
    {
        _context = context;
       
    }
    
}