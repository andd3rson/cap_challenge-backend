using EmployeeManagement.Application.Department.CreateDepartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/department")]
public class DepartmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateDepartmentCommand request)
        => await _mediator.Send(request) ? Ok() : BadRequest();
    
}