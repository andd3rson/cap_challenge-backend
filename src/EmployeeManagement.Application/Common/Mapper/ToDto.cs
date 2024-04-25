using AutoMapper;
using EmployeeManagement.Application.Department.Queries.GetDepartment;
using EmployeeManagement.Application.Employee.Queries.GetEmployee;

namespace EmployeeManagement.Application.Common.Mapper;


public class ToDto : Profile
{
    public ToDto()
    {
        CreateMap<Domain.Entity.Department, GetDepartmentResponse>();
        CreateMap<GetEmployeeResponse, Domain.Entity.Employee>();
    }
}