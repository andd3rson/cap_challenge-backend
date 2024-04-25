using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Employee.Commands.UpdateEmployee;


public class UpdateEmployeeCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Salary { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
}

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeManagementContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Domain.Entity.Employee>(request);
        _context.Employees.Update(employee);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}