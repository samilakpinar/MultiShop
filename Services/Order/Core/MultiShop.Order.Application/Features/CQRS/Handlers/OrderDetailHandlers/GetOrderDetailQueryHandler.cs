using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailByIdQueryResult>> Handle()
        {
            var orderDetails = await _repository.GetAllAsync();
            if (orderDetails == null || !orderDetails.Any())
            {
                return new List<GetOrderDetailByIdQueryResult>();
            }
            // Mapping OrderDetail to GetOrderDetailByIdQueryResult
            var result = orderDetails.Select(od => new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = od.OrderDetailId,
                ProductId = od.ProductId,
                ProdcutName = od.ProductName,
                ProductPrice = od.ProductPrice,
                ProductAmount = od.ProductAmount,
                ProductTotalPrice = od.ProductTotalPrice,
                OrderingId = od.OrderingId
            }).ToList();
            return result;
        }
    }
}
