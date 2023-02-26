using FluentValidation.AspNetCore;
using ProductService;
using SharedLibrary.Helpers;
using SharedLibrary.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<CustomValidationFilter>())
                 .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining(typeof(ProductService.Infrastructure.FluentValidation.ProductCreateRequestValidator)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ServiceRegistration.ProductServiceRegistration(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("v1/swagger.json", "ProductServiceV1");
});
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();
app.MapControllers();
app.Run();
