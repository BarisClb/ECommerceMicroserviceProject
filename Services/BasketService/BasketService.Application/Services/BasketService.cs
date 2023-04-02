using BasketService.Application.Models.Entities;
using BasketService.Application.Models.Requests;
using BasketService.Application.Repositories;

namespace BasketService.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }


        public async Task<Basket> GetBasket(Guid userId)
        {
            return await _basketRepository.GetBasket(userId.ToString()) ?? await _basketRepository.SetBasket(new Basket() { UserId = userId, Items = new List<BasketItem>() });
        }

        public async Task<Basket> UpdateOrCreateBasket(Basket basket)
        {
            return await _basketRepository.SetBasket(basket);
        }

        public async Task<bool> DeleteBasket(Guid userId)
        {
            await _basketRepository.DeleteBasket(userId.ToString());
            return true;
        }

        public async Task<Basket> IncreaseOrAddBasketItem(UpdateBasketForItemRequest increaseOrAddBasketItemRequest)
        {
            var basket = await GetBasket(increaseOrAddBasketItemRequest.UserId);
            var item = basket.Items.Find(item => item.Id == increaseOrAddBasketItemRequest.BasketItemId);

            if (item == null)
                basket.Items.Add(new BasketItem() { Id = increaseOrAddBasketItemRequest.BasketItemId, Name = increaseOrAddBasketItemRequest.BasketItemName ?? "", Price = increaseOrAddBasketItemRequest.BasketItemPrice ?? 0.00M, Quantity = increaseOrAddBasketItemRequest.BasketItemQuantity ?? 0 });
            else
                item.Quantity++;

            return await UpdateOrCreateBasket(basket);
        }

        public async Task<Basket> DecreaseOrDeleteBasketItem(UpdateBasketForItemRequest decreaseOrDeleteBasketItemRequest)
        {
            var basket = await GetBasket(decreaseOrDeleteBasketItemRequest.UserId);
            var item = basket.Items.Find(item => item.Id == decreaseOrDeleteBasketItemRequest.BasketItemId);

            if (item != null)
            {
                if (item.Quantity > 1)
                    item.Quantity--;
                else
                    basket.Items.Remove(item);
            }

            return await UpdateOrCreateBasket(basket);
        }

        public async Task<Basket> UpdateBasketItemQuantity(UpdateBasketForItemRequest updateBasketItemQuantityRequest)
        {
            var basket = await GetBasket(updateBasketItemQuantityRequest.UserId);
            var item = basket.Items.Find(item => item.Id == updateBasketItemQuantityRequest.BasketItemId);

            if (item == null)
                basket.Items.Add(new BasketItem() { Id = updateBasketItemQuantityRequest.BasketItemId, Name = updateBasketItemQuantityRequest.BasketItemName ?? "", Price = updateBasketItemQuantityRequest.BasketItemPrice ?? 0.00M, Quantity = updateBasketItemQuantityRequest.BasketItemQuantity ?? 0 });
            else
                item.Quantity = updateBasketItemQuantityRequest.BasketItemQuantity ?? 0;

            return await UpdateOrCreateBasket(basket);
        }

        public async Task<Basket> DeleteBasketItem(UpdateBasketForItemRequest deleteBasketItemRequest)
        {
            var basket = await GetBasket(deleteBasketItemRequest.UserId);
            var item = basket.Items.Find(item => item.Id == deleteBasketItemRequest.BasketItemId);

            if (item != null)
                basket.Items.Remove(item);

            return await UpdateOrCreateBasket(basket);
        }

        public async Task<Basket> ClearBasketItems(Guid userId)
        {
            var basket = await GetBasket(userId);

            if (basket.Items.Count > 0)
                basket.Items.Clear();

            return await UpdateOrCreateBasket(basket);
        }
    }
}
