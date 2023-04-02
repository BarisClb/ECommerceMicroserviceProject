using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SharedLibrary.Helpers;
using SharedLibrary.Middlewares;
using UserService.Application;
using UserService.Infrastructure;
using UserService.Persistence;
using UserService.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<CustomValidationFilter>())
                 .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining(typeof(UserService.Infrastructure.FluentValidation.UserValidators)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.UserServicePersistenceServiceRegistration(builder.Configuration);
builder.Services.UserServiceInfrastructureServiceRegistration();
builder.Services.UserServiceApplicationServiceRegistration();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("v1/swagger.json", "UserService");
});
app.UseMiddleware<ErrorHandlerMiddleware>();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ECommerceMicroserviceProjectDbContext>();
    RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
    context.Database.EnsureCreated();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
