using AutoMapper;
using EmployeeManagement.Application.Department.Queries.GetDepartment;
using EmployeeManagement.Application.Employee.Queries.GetEmployee;
using EmployeeManagement.Application.Project.Queries.GetProject;

namespace EmployeeManagement.Application.Common.Mapper;

public class ToDto : Profile
{
    public ToDto()
    {
        CreateMap<Domain.Entity.Department, GetDepartmentResponse>();
        CreateMap<Domain.Entity.Employee, GetEmployeeResponse>();
        CreateMap<Domain.Entity.Project, GetProjectResponse>();
        
    }
}