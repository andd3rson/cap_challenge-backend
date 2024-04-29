using EmployeeManagement.Infrastructure;
using EmployeeManagement.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);;


builder.Services.AddEndpointsApiExplorer();
// TODO: Change it
var conn = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddInfrastructureServices(conn);
builder.Services.AddApplicationServices();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p =>
    p.AddPolicy("allowCors", configurePolicy => { configurePolicy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allowCors");
app.UseAuthorization();

app.MapControllers();

app.Run();