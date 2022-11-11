using System.Reflection;
using TwojUrlop.DependencyInjection.Extensions;
using TwojUrlop.Extensions;

var builder = WebApplication.CreateBuilder(args);

var projectName = Assembly.GetExecutingAssembly().GetName().Name;

builder.Services.ConfigureCommonServices(builder.Configuration, projectName!);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDomainHandlers();

var app = builder.Build();

bool isDevelopment = app.Environment.IsDevelopment();
if (isDevelopment)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCommonPipeline(isDevelopment);


app.MapControllers();

app.Run();

