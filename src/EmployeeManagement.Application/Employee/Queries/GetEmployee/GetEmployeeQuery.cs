using AutoMapper;
using EmployeeManagement.Application.Common;
using EmployeeManagement.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Employee.Queries.GetEmployee;

public class GetEmployeeQuery : IRequest<PagedList<GetEmployeeResponse>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 1;
    public string? Search { get; set; } = String.Empty;
}

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, PagedList<GetEmployeeResponse>>
{
    private readonly IEmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public GetEmployeeQueryHandler(IEmployeeManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedList<GetEmployeeResponse>> Handle(GetEmployeeQuery request,
        CancellationToken cancellationToken)
    {
        var query =
            await _context.Employees
                .Include(j => j.Department)
                .Include(j => j.Projects)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);


        var mappedEmployee = _mapper.Map<List<GetEmployeeResponse>>(query);

        var paginatedEmployee =
            PagedList<GetEmployeeResponse>.CreateAsync(mappedEmployee,
                request.Page,
                request.PageSize,
                await _context.Employees.CountAsync(cancellationToken));

        return await Task.FromResult(paginatedEmployee);
    }
}