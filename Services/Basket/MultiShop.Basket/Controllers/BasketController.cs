using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginService;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;
        public BasketController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var userId = "ecd66f412-4fa8-rtd68-30a93da53fa";// _loginService.GetUserId; //userId örnek verilebilir. 
            if (string.IsNullOrEmpty(userId))
            {
                return NotFound("User not found");
            }
            var basket = await _basketService.GetBasketAsync(userId);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket([FromBody] BasketTotalDto basketTotalDto)
        {
            if (basketTotalDto == null || string.IsNullOrEmpty(basketTotalDto.UserId))
            {
                return BadRequest("Invalid basket data");
            }
            basketTotalDto.UserId = "ecd66f412-4fa8-rtd68-30a93da53fa";//_loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepetteki değişiklikler kaydedildi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var userId = "ecd66f412-4fa8-rtd68-30a93da53fa"; //_loginService.GetUserId;
            if (string.IsNullOrEmpty(userId))
            {
                return NotFound("User not found");
            }
            await _basketService.DeleteBasketAsync(userId);
            return Ok("Sepetiniz silindi.");
        }
    }
}
