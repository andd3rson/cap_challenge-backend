using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Project.Queries.GetProject;


public class GetProjectQuery : IRequest<List<GetProjectResponse>>
{
}

public class GetEmployeeQueryHandler : IRequestHandler<GetProjectQuery, List<GetProjectResponse>>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public GetEmployeeQueryHandler(IEmployeeManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetProjectResponse>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Projects
            .Include(x=>x.Employees)
            .ToListAsync(cancellationToken);
        var mappedProjects = _mapper.Map<List<GetProjectResponse>>(query);
        return mappedProjects;
    }
}