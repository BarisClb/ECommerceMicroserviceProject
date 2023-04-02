using BasketService.Application;
using SharedLibrary.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.BasketServiceApplicationServiceRegistration(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("v1/swagger.json", "BasketService");
});
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();
app.MapControllers();
app.Run();
