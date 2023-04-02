using BasketService.Application.Models.Entities;

namespace BasketService.Application.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasket(string userId);
        Task<Basket> SetBasket(Basket basket);
        Task DeleteBasket(string userId);
    }
}
