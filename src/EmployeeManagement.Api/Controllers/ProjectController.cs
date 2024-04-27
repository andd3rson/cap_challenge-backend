using EmployeeManagement.Application.Project.Commands.CreateProject;
using EmployeeManagement.Application.Project.Commands.RemoveProject;
using EmployeeManagement.Application.Project.Commands.UpdateProject;
using EmployeeManagement.Application.Project.Queries.GetProject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _mediator.Send(new GetProjectQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var projects = await _mediator.Send(new GetProjectByIdQuery() { Id = id });
        return projects is null ? NotFound() : Ok(projects);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand request)
    {
        var response = await _mediator.Send(request);
        return Created($"api/projects/{response}", request);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put([FromBody] UpdateProjectCommand request, int id)
    {
        if (request.Id != id)
            return BadRequest();

        return await _mediator.Send(request) ? NoContent() : BadRequest();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new RemoveProjectCommand() { Id = id });
        return Ok();
    }
}