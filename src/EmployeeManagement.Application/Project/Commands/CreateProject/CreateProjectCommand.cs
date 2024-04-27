using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Project.Commands.CreateProject;

public class CreateProjectCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Details { get; set; }
    public string ManagerName { get; set; }
}

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public CreateProjectCommandHandler(IMapper mapper, IEmployeeManagementContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _mapper.Map<Domain.Entity.Project>(request);
        _context.Projects.Add(project);

        await _context.SaveChangesAsync(cancellationToken);

        return project.Id;
    }
}