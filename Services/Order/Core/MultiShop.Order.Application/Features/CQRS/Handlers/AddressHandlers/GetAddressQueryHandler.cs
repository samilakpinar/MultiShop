using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressByIdQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();

            if (values == null || !values.Any())
            {
                throw new InvalidOperationException("No addresses found.");
            }

            return values.Select(x => new GetAddressByIdQueryResult
            {
                AddressId = x.AddressId,
                UserId = x.UserId,
                District = x.District,
                City = x.City,
                Detail = x.Detail
            }).ToList();
        }
    }
}
