using AutoMapper;
using EmployeeManagement.Application.Department.Queries.GetDepartment;

namespace EmployeeManagement.Application.Common.Mapper;


public class ToDto : Profile
{
    public ToDto()
    {
        CreateMap<Domain.Entity.Department, GetDepartmentResponse>();
    }
}