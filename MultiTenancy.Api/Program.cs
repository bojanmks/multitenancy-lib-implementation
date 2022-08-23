using MultiTenancy.Api.Core;
using MultiTenancy.Api.Core.Extensions;
using MultiTenancy.Api.Core.Middleware;
using MultiTenancy.Application.Logging;
using MultiTenancy.Implementation;
using MultiTenancy.Implementation.Logging;
using MultiTenancy.Implementation.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);
builder.Services.AddSingleton(appSettings);

builder.AddApplicationActor();
builder.AddDbContext(appSettings);
builder.AddJwt(appSettings);
builder.AddUseCaseValidators();
builder.AddUseCaseHandlers();

builder.Services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
builder.Services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
builder.Services.AddTransient<UseCaseMediator>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

ServiceProviderActivator.SetUpProvider(app.Services);

app.Run();
