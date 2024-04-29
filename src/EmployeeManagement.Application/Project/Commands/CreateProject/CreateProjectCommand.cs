using AutoMapper;
using EmployeeManagement.Application.Common.Exceptions;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Project.Commands.CreateProject;

public class CreateProjectCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Details { get; set; }
    public string ManagerName { get; set; }
    public List<int> EmployeesId { get; set; }
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

        project = await GettingEmployees(request.EmployeesId, project, cancellationToken);
        _context.Projects.Add(project);
        await _context.SaveChangesAsync(cancellationToken);
        return project.Id;
    }

    
    private async Task<Domain.Entity.Project> GettingEmployees(List<int> employeesId, Domain.Entity.Project project,
        CancellationToken cancellationToken)
    {
        foreach (var req in employeesId)
        {
            var exists = await _context.Employees.FirstOrDefaultAsync(
                x => x.Id == req, cancellationToken);
            if (exists is null)
                throw new ValidationException();

            project.Employees.Add(exists);
        }

        return project;
    }
}