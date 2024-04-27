using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Employee.Queries.GetEmployee;

public class GetEmployeeQuery : IRequest<List<GetEmployeeResponse>>
{
}

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<GetEmployeeResponse>>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public GetEmployeeQueryHandler(IEmployeeManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetEmployeeResponse>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var query =
            await _context.Employees
                .Include(j => j.Department)
                .Include(j => j.Projects)
                .ToListAsync(cancellationToken);
        
        var mappedEmployee = _mapper.Map<List<GetEmployeeResponse>>(query);
        return mappedEmployee;
    }
}