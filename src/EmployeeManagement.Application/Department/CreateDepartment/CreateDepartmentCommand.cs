using EmployeeManagement.Application.Common.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Department.CreateDepartment;

public record CreateDepartmentCommand(String Name) : IRequest<bool>;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, bool>
{
    private readonly IEmployeeManagementContext _context;

    public CreateDepartmentCommandHandler(IEmployeeManagementContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

