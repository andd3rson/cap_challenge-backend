using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Department.Queries.GetDepartment;

public class GetDepartmentCommand : IRequest<List<GetDepartmentResponse>>
{
}

public class GetDepartmentCommandHandler : IRequestHandler<GetDepartmentCommand, List<GetDepartmentResponse>>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public GetDepartmentCommandHandler(IEmployeeManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetDepartmentResponse>> Handle(GetDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        var departments =
            await _context.Departments.ToListAsync(cancellationToken);
        var mappedDepartment = _mapper.Map<List<GetDepartmentResponse>>(departments);

        return mappedDepartment;
    }
}