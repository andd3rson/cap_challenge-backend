using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Employee.Commands.CreateEmployee;

public class CreateEmployeeCommand : IRequest<int>
{
    public string Fullname { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public double Salary { get; set; }
    public DateTime BirthDate { get; set; }
   
    public int? DepartmentId { get; set; }
}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeManagementContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Domain.Entity.Employee>(request);
        _context.Employees.Add(employee);

        await _context.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}