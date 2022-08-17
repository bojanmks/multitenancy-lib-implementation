using MultiTenancy.Api.Core;
using MultiTenancy.Api.Core.Middleware;
using MultiTenancy.Api.Extensions;
using MultiTenancy.Application.Logging;
using MultiTenancy.Implementation.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);
builder.Services.AddSingleton(appSettings);

builder.AddApplicationUser();
builder.AddJwt(appSettings);

builder.Services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
