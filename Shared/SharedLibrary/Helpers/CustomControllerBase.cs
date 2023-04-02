using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace SharedLibrary.Helpers
{
    public class CustomControllerBase : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(BaseResponse<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }

        //[HttpGet("automappercontrol")]
        //public async Task<IActionResult> AutoMapperControl()
        //{
        //    try
        //    {
        //        _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    },
        //    return Ok();
        //}
    }
}
