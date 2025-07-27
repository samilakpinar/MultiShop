using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class DeleteOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }


        public async Task Handle(int id)
        {            
            var orderDetail = await _repository.GetByIdAsync(id);

            if (orderDetail == null)
            {
                throw new KeyNotFoundException($"OrderDetail with ID {id} not found");
            }
            await _repository.DeleteAsync(orderDetail);
        }

    }
}
