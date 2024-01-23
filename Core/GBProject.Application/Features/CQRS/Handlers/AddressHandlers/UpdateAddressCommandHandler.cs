using GbProject.Domain.Entities;
using GBProject.Application.Features.CQRS.Commands.AddressCommands;
using GBProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GBProject.Application.Features.CQRS.Handlers.AddressHandlers
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
            var values = await _repository.GetByIdAsync(command.AddressId);
            values.Description = command.Description;
            values.CustomerId = command.CustomerId;
            await _repository.UpdateAsync(values);

        }
    }
}
