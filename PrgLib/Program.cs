
using PrgLib.Startup;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterDbServices(builder);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.RegisterStandardServices();
builder.Services.RegisterAppServices();
builder.Services.RegisterApiServices();
var app = builder.Build();
var env = builder.Environment;

// Configure the HTTP request pipeline.
app.ConfigureExceptionHandler(env);
app.ConfigureSwagger();
app.UseHttpsRedirection();
app.MapProgramTypeEndpoints();

app.Run();
