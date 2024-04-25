using AutoMapper;
using EmployeeManagement.Application.Department.Commands.CreateDepartment;
using EmployeeManagement.Application.Department.Commands.UpdateDepartment;
using EmployeeManagement.Application.Department.Queries.GetDepartment;

namespace EmployeeManagement.Application.Common.Mapper;

public class ToEntity : Profile
{
    public ToEntity()
    {
        CreateMap<CreateDepartmentCommand, Domain.Entity.Department>();
        CreateMap<Domain.Entity.Department, GetDepartmentResponse>();
        CreateMap<UpdateDepartmentCommand, Domain.Entity.Department>();
    }
}