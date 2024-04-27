using AutoMapper;
using EmployeeManagement.Application.Common.Exceptions;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Department.Commands.RemoveDepartment;

public class RemoveDepartmentCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class RemoveDepartmentCommandHandler : IRequestHandler<RemoveDepartmentCommand, bool>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public RemoveDepartmentCommandHandler(IEmployeeManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(RemoveDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _context.Departments
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (department is null)
            throw new ValidationException();

        _context.Departments.Remove(department);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}