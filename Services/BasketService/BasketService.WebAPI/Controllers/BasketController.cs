using BasketService.Application.Models.Entities;
using BasketService.Application.Models.Requests;
using BasketService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.WebAPI.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }


        [HttpGet("getBasket/{userId}")]
        public async Task<IActionResult> GetBasket(Guid userId)
        {
            return Ok(await _basketService.GetBasket(userId));
        }

        [HttpPost("updateOrCreateBasket")]
        public async Task<IActionResult> UpdateBasket(Basket basket)
        {
            return Ok(await _basketService.UpdateOrCreateBasket(basket));
        }

        [HttpPut("increaseOrAddBasketItem")]
        public async Task<IActionResult> IncreaseOrAddBasketItem(UpdateBasketForItemRequest increaseOrAddBasketItemRequest)
        {
            return Ok(await _basketService.IncreaseOrAddBasketItem(increaseOrAddBasketItemRequest));
        }

        [HttpPut("decreaseOrDeleteBasketItem")]
        public async Task<IActionResult> DecreaseOrDeleteBasketItem(UpdateBasketForItemRequest decreaseOrDeleteBasketItemRequest)
        {
            return Ok(await _basketService.DecreaseOrDeleteBasketItem(decreaseOrDeleteBasketItemRequest));
        }

        [HttpPut("updateBasketItemQuantity")]
        public async Task<IActionResult> UpdateBasketItemQuantity(UpdateBasketForItemRequest updateBasketItemQuantityRequest)
        {
            return Ok(await _basketService.UpdateBasketItemQuantity(updateBasketItemQuantityRequest));
        }

        [HttpDelete("deleteBasket/{userId}")]
        public async Task<IActionResult> DeleteBasket(Guid userId)
        {
            return Ok(await _basketService.DeleteBasket(userId));
        }

        [HttpDelete("clearBasketItems/{userId}")]
        public async Task<IActionResult> ClearBasketItems(Guid userId)
        {
            return Ok(await _basketService.ClearBasketItems(userId));
        }

        [HttpDelete("deleteBasketItem")]
        public async Task<IActionResult> DeleteBasketItem(UpdateBasketForItemRequest deleteBasketItemRequest)
        {
            return Ok(await _basketService.DeleteBasketItem(deleteBasketItemRequest));
        }
    }
}
