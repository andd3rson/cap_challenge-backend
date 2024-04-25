using EmployeeManagement.Application.Employee.Commands.CreateEmployee;
using EmployeeManagement.Application.Employee.Commands.UpdateEmployee;
using EmployeeManagement.Application.Employee.Queries.GetEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _mediator.Send(new GetEmployeeQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var employee = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });
        return employee is null ? NotFound() : Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateEmployeeCommand request)
    {
        var response = await _mediator.Send(request);
        return Created($"api/employee/{response}", request);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put([FromBody] UpdateEmployeeCommand request, int id)
    {
        if (request.Id != id)
            return BadRequest();

        return await _mediator.Send(request) ? NoContent() : BadRequest();
    }

    // TODO: Still figuring it out if need to put a boolean flag "actived" or not 
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }
}