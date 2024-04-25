using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Project.Commands.UpdateProject;

public class UpdateProjectCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public string ManagerName { get; set; }
}

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, bool>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public UpdateProjectCommandHandler(IMapper mapper, IEmployeeManagementContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _mapper.Map<Domain.Entity.Project>(request);
        _context.Projects.Update(project);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}