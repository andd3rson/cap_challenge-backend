using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Department.Queries.GetDepartment;
public class GetDepartmentByIdQuery : IRequest<GetDepartmentResponse>
{
    public int Id { get; set; }
}

public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, GetDepartmentResponse>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public GetDepartmentByIdQueryHandler(IEmployeeManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetDepartmentResponse> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Departments
                                            .FirstOrDefaultAsync(
                                                x => 
                                                    x.Id == request.Id, cancellationToken);
       
        var mappedProject = _mapper.Map<GetDepartmentResponse>(query);
        return mappedProject;
    }
}