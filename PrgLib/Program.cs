using Microsoft.EntityFrameworkCore;
using PrgLib.Infrastructure.Data;
using PrgLib.Startup;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.
GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(o
=> o.UseSqlServer(connectionString));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.RegisterStandardServices();
builder.Services.RegisterAppServices();
builder.Services.RegisterApiServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureSwagger();
app.UseHttpsRedirection();
app.MapProgramTypeEndpoints();

app.Run();
