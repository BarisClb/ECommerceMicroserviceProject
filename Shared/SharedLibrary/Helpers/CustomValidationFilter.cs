using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace SharedLibrary.Helpers
{
    public class CustomValidationFilter : IAsyncActionFilter
    {
        private readonly ILogger<CustomValidationFilter> _logger;

        public CustomValidationFilter(ILogger<CustomValidationFilter> logger)
        {
            _logger = logger;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                _logger.LogError("Model state is not valid.");
                return;
            }

            await next();
        }
    }
}
