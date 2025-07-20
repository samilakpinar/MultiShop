﻿using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAddressCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), "Command cannot be null");
            }

            var address = await _repository.GetByIdAsync(command.Id);
            if (address == null)
            {
                throw new KeyNotFoundException($"Address with ID {command.Id} not found.");
            }
            // Adresi sil
            await _repository.DeleteAsync(address);
        }
    }
}
