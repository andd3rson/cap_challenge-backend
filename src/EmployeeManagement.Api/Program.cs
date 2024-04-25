using EmployeeManagement.Infrastructure;
using EmployeeManagement.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
// TODO: Change it
var conn = "Server=localhost,1433;Database=MVP;user=sa;password=password@123;";
builder.Services.AddInfrastructureServices(conn);
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();