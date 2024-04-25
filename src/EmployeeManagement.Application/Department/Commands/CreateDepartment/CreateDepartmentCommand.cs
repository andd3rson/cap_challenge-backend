using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Department.Commands.CreateDepartment;

public record CreateDepartmentCommand(String Name) : IRequest<bool>;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, bool>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public CreateDepartmentCommandHandler(IEmployeeManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.Entity.Department>(request);
        _context.Departments.Add(entity);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}