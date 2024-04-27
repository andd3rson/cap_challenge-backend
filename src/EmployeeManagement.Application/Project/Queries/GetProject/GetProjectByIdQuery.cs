using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Project.Queries.GetProject;

public class GetProjectByIdQuery : IRequest<GetProjectResponse>
{
    public int Id { get; set; }
}

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, GetProjectResponse>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public GetEmployeeByIdQueryHandler(IEmployeeManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetProjectResponse> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var query = 
            await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        var mappedProjects = _mapper.Map<GetProjectResponse>(query);
        return mappedProjects;
    }
}