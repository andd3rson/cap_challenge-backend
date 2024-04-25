using AutoMapper;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Employee.Queries.GetEmployee;

public class GetEmployeeByIdQuery : IRequest<GetEmployeeResponse>
{
    public int Id { get; set; }
}

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeResponse>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public GetEmployeeByIdQueryHandler(IEmployeeManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetEmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Employees
                                            .FirstOrDefaultAsync(
                                                x => 
                                                    x.Id == request.Id, cancellationToken);
       
        var mappedEmployee = _mapper.Map<GetEmployeeResponse>(query);
        return mappedEmployee;
    }
}