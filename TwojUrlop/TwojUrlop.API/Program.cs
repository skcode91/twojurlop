using System.Reflection;
using TwojUrlop.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

var projectName = Assembly.GetExecutingAssembly().GetName().Name;

builder.Services.ConfigureCommonServices(builder.Configuration, projectName!);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();

