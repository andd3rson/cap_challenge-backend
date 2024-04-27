using AutoMapper;
using EmployeeManagement.Application.Common.Exceptions;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Project.Commands.RemoveProject;

public class RemoveProjectCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class RemoveProjectCommandHandler : IRequestHandler<RemoveProjectCommand, bool>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public RemoveProjectCommandHandler(IEmployeeManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(RemoveProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (project is null)
            throw new ValidationException();
        _context.Projects.Remove(project);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}