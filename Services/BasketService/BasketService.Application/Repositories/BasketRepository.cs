using BasketService.Application.Models.Entities;
using BasketService.Application.Settings;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using SharedLibrary.Extensions;

namespace BasketService.Application.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;
        private readonly IOptions<RedisSettings> _redisSettings;

        public BasketRepository(IDistributedCache redisCache, IOptions<RedisSettings> redisSettings)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
            _redisSettings = redisSettings;
        }


        public Task<Basket> GetBasket(string userId)
        {
            return _redisCache.GetRecordAsync<Basket>(userId);
        }

        public async Task<Basket> SetBasket(Basket basket)
        {
            await _redisCache.SetRecordAsync<Basket>(basket.UserId.ToString(), basket, _redisSettings.Value.AbsoluteExpireTime != null ? TimeSpan.FromSeconds(_redisSettings.Value.AbsoluteExpireTime ?? 0) : null, _redisSettings.Value.UnusedExpireTime != null ? TimeSpan.FromSeconds(_redisSettings.Value.UnusedExpireTime ?? 0) : null);
            return await GetBasket(basket.UserId.ToString());
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisCache.RemoveAsync(userId);
        }
    }
}
