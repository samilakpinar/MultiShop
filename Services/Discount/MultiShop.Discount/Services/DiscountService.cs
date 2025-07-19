using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            //dapper üzerinde ekleme işlemi:
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code, @rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAync(int couponId)
        {
            var query = "Delete From Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            var query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return result.ToList();
            }
        }

        public async Task<ResultDiscountCouponDto> GetDiscountCouponByIdAsync(int couponId)
        {
            var query = "Select * From Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parameters);
                return result;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            var query = "Update Coupons set Code = @code, Rate = @rate, IsActive = @isActive, ValidDate = @validDate where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", updateCouponDto.CouponId);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
