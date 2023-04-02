using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace SharedLibrary.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, string recordId, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? unusedExpireTime = null)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime; // Data will expire after this time, even if it's recently used.
            options.SlidingExpiration = unusedExpireTime; // If the Data doesn't get used in this time frame, it will expire.

            string jsonData = JsonConvert.SerializeObject(data);
            await cache.SetStringAsync(recordId, jsonData);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            string jsonData = await cache.GetStringAsync(recordId);

            return jsonData == null ? default(T) : JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}
