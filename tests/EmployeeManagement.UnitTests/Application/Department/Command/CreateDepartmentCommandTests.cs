using AutoMapper;
using EmployeeManagement.Application.Department.Commands.CreateDepartment;
using EmployeeManagement.Infrastructure.DataAccess;
using EmployeeManagement.UnitTests.Fixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.UnitTests.Application.Department.Command;

public class CreateDepartmentCommandTests : TestFixture
{
    private readonly EmployeeManagementContext _context;
    private readonly IMapper _mapper;

    public CreateDepartmentCommandTests()
    {
        _mapper = base.Mapper;
        _context = base.Context;
    }

    [Fact]
    public async Task ShouldPersistDepartment()
    {
        // Arrange
        var createDepartmentCommand = new CreateDepartmentCommand("IT Department");


        var handler = new CreateDepartmentCommandHandler(_context, _mapper);

        // Act
        await handler.Handle(createDepartmentCommand,
            CancellationToken.None);

        // Assert
        var entity = await _context.Departments.FirstAsync();

        entity.Should().NotBeNull();
        entity.Name.Should().Be(createDepartmentCommand.Name);
    }
}