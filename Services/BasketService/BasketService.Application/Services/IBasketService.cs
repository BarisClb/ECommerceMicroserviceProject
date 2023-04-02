using BasketService.Application.Models.Entities;
using BasketService.Application.Models.Requests;

namespace BasketService.Application.Services
{
    public interface IBasketService
    {
        Task<Basket> GetBasket(Guid userId);
        Task<Basket> UpdateOrCreateBasket(Basket basket);
        Task<bool> DeleteBasket(Guid userId);
        Task<Basket> IncreaseOrAddBasketItem(UpdateBasketForItemRequest increaseOrAddBasketItemRequest);
        Task<Basket> DecreaseOrDeleteBasketItem(UpdateBasketForItemRequest decreaseOrDeleteBasketItemRequest);
        Task<Basket> UpdateBasketItemQuantity(UpdateBasketForItemRequest updateBasketItemQuantityRequest);
        Task<Basket> DeleteBasketItem(UpdateBasketForItemRequest deleteBasketItemRequest);
        Task<Basket> ClearBasketItems(Guid userId);
    }
}
