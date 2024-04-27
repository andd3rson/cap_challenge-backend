using AutoMapper;
using EmployeeManagement.Application.Common.Exceptions;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Employee.Commands.RemoveEmployee;

public class RemoveEmployeeCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand, bool>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public RemoveEmployeeCommandHandler(IEmployeeManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (employee is null)
            throw new ValidationException();

        _context.Employees.Remove(employee);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}