using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscountCoupons()
        {
            var result = await _discountService.GetAllDiscountCouponAsync();
            return Ok(result);
        }

        [HttpGet("{couponId}")]
        public async Task<IActionResult> GetDiscountCouponById(int couponId)
        {
            var result = await _discountService.GetDiscountCouponByIdAsync(couponId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon([FromBody] CreateDiscountCouponDto createCouponDto)
        {
            if (createCouponDto == null)
            {
                return BadRequest("Coupon data is null");
            }
            await _discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Kupon başarıyla oluşturuldu");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int couponId)
        {
            await _discountService.DeleteDiscountCouponAync(couponId);
            return Ok("Kupon başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon([FromBody] UpdateDiscountCouponDto updateCouponDto)
        {
            if (updateCouponDto == null)
            {
                return BadRequest("Coupon data is null");
            }
            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("İndirim Kupon başarıyla güncellendi");
        }

    }
}
