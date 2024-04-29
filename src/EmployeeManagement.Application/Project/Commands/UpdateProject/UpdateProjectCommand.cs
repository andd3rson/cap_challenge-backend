using EmployeeManagement.Application.Common.Exceptions;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Project.Commands.UpdateProject;

public class UpdateProjectCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public string ManagerName { get; set; }
    public List<int> EmployeesId { get; set; }
}

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, bool>
{
    private readonly IEmployeeManagementContext _context;


    public UpdateProjectCommandHandler(IEmployeeManagementContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var projectToBeUpdated =
            await _context.Projects
                .Include(x=>x.Employees)
                .FirstAsync(x => x.Id == request.Id, cancellationToken);
        projectToBeUpdated = await MappingEmployees(request, projectToBeUpdated, cancellationToken);
        _context.Projects.Update(projectToBeUpdated);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }


    private async Task<Domain.Entity.Project> MappingEmployees(UpdateProjectCommand employees,
        Domain.Entity.Project project,
        CancellationToken cancellationToken)
    {
        project!.ManagerName = employees.ManagerName;
        project.Details = employees.Details;
        project.Employees = new List<Domain.Entity.Employee?>();

        foreach (var req in employees.EmployeesId)
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