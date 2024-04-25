using AutoMapper;
using EmployeeManagement.Application.Department.CreateDepartment;

namespace EmployeeManagement.Application.Common.Mapper;

public class ToEntity : Profile
{
    public ToEntity()
    {
        CreateMap<CreateDepartmentCommand, Domain.Entity.Department>();
    }
}