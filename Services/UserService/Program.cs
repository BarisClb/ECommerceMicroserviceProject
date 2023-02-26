using FluentValidation.AspNetCore;
using SharedLibrary.Helpers;
using SharedLibrary.Middlewares;
using UserService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<CustomValidationFilter>())
                 .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining(typeof(UserService.Infrastructure.FluentValidation.UserValidators)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ServiceRegistration.UserServiceRegistration(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("v1/swagger.json", "UserServiceV1");
});
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();
app.MapControllers();
app.Run();
