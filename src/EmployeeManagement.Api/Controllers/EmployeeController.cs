using EmployeeManagement.Application.Employee.Commands.CreateEmployee;
using EmployeeManagement.Application.Employee.Commands.RemoveEmployee;
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
    public async Task<IActionResult> Get(int page, int pageSize, string? search)
        => Ok(await _mediator.Send(new GetEmployeeQuery() { Page = page, PageSize = pageSize, Search = search }));

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
        return Created($"api/employees/{response}", request);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put([FromBody] UpdateEmployeeCommand request, int id)
    {
        if (request.Id != id)
            return BadRequest();
        return await _mediator.Send(request) ? NoContent() : BadRequest();
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new RemoveEmployeeCommand { Id = id }));
}