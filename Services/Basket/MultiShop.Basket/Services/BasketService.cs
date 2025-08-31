using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasketAsync(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);            
        }

        public async Task<BasketTotalDto> GetBasketAsync(string userId)
        {
            //var user = User.Calims;
            var existingBasket = await _redisService.GetDb().StringGetAsync(userId);
            if(string.IsNullOrEmpty(existingBasket))
            {
                throw new Exception($"Basket not found for user: {userId}");
            }
            return JsonSerializer.Deserialize<BasketTotalDto>(existingBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
