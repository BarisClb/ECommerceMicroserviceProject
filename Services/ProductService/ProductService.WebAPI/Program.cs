using FluentValidation.AspNetCore;
using ProductService.Application;
using ProductService.Infrastructure;
using ProductService.Persistence;
using SharedLibrary.Helpers;
using SharedLibrary.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<CustomValidationFilter>())
                 .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining(typeof(ProductService.Infrastructure.FluentValidation.ProductCreateRequestValidator)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ProductServiceInfrastructureServiceRegistration();
builder.Services.ProductServicePersistenceServiceRegistration();
builder.Services.ProductServiceApplicationServiceRegistration(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("v1/swagger.json", "ProductService");
});
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();
app.MapControllers();
app.Run();
