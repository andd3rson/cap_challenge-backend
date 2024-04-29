using AutoMapper;
using EmployeeManagement.Application.Common.Mapper;

namespace EmployeeManagement.UnitTests.Fixture;

public static class MapperFixture
{
    public static IMapper Create()
    {
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ToDto>();
            cfg.AddProfile<ToEntity>();
        });

        return configurationProvider.CreateMapper();
    }
}