using System.Reflection;
using TwojUrlop.Common.Models.Settings;
using TwojUrlop.DependencyInjection.Extensions;
using TwojUrlop.Extensions;

var builder = WebApplication.CreateBuilder(args);

var projectName = Assembly.GetExecutingAssembly().GetName().Name;

builder.Services.ConfigureCommonServices(builder.Configuration, projectName!);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDomainHandlers();

var app = builder.Build();

bool isDevelopment = app.Environment.IsDevelopment();
var securitySettings = app.Configuration.GetSection("Security").Get<SecuritySettings>()!;

if (isDevelopment)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCommonPipeline(securitySettings, isDevelopment);


app.MapControllers();

app.Run();

