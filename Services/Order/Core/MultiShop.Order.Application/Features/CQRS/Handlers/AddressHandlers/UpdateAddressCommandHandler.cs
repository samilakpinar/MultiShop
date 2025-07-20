using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), "Command cannot be null");
            }
            // Fetch the existing address
            var address = await _repository.GetByIdAsync(command.AddressId);
            if (address == null)
            {
                throw new KeyNotFoundException($"Address with ID {command.AddressId} not found.");
            }
            // Update the properties
            address.District = command.District;
            address.City = command.City;
            address.Detail = command.Detail;
            address.UserId = command.UserId;
            // Save changes
            await _repository.UpdateAsync(address);
        }
    }
}
