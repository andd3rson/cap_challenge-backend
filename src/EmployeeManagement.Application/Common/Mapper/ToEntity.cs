using AutoMapper;
using EmployeeManagement.Application.Department.Commands.CreateDepartment;
using EmployeeManagement.Application.Department.Commands.UpdateDepartment;
using EmployeeManagement.Application.Employee.Commands.CreateEmployee;
using EmployeeManagement.Application.Employee.Commands.UpdateEmployee;
using EmployeeManagement.Application.Project.Commands.CreateProject;
using EmployeeManagement.Application.Project.Commands.UpdateProject;

namespace EmployeeManagement.Application.Common.Mapper;

public class ToEntity : Profile
{
    public ToEntity()
    {
        CreateMap<CreateDepartmentCommand, Domain.Entity.Department>();
        CreateMap<UpdateDepartmentCommand, Domain.Entity.Department>();
        
        CreateMap<CreateEmployeeCommand, Domain.Entity.Employee>();
        CreateMap<UpdateEmployeeCommand, Domain.Entity.Employee>();
        
        
        CreateMap<CreateProjectCommand, Domain.Entity.Project>();
        CreateMap<UpdateProjectCommand, Domain.Entity.Project>();
    }
}