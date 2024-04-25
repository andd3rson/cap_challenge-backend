using EmployeeManagement.Application.Department.Commands.CreateDepartment;
using EmployeeManagement.Application.Department.Commands.UpdateDepartment;
using EmployeeManagement.Application.Department.Queries.GetDepartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/departments")]
public class DepartmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetDepartmentQuery()));
    }

    [HttpPost]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] CreateDepartmentCommand request)
        => await _mediator.Send(request) ? Created("api/department", request) : BadRequest();


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put([FromBody] UpdateDepartmentCommand request, int id)
    {
        if (request.Id != id) return BadRequest("Try again later");
        return await _mediator.Send(request) ? NoContent() : BadRequest();
    }
}