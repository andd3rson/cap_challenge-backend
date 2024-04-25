using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Department.Commands.UpdateDepartment;

public class UpdateDepartmentCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, bool>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public UpdateDepartmentCommandHandler(IMapper mapper, IEmployeeManagementContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = _mapper.Map<Domain.Entity.Department>(request);
        _context.Departments.Update(department);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}