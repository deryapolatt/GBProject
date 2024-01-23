using GbProject.Domain.Entities;
using GBProject.Application.Features.CQRS.Commands.CustomerCommands;
using GBProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GBProject.Application.Features.CQRS.Handlers.CustomerHandlers
{
    public class UpdateCustomerCommandHandler
    {
        private readonly IRepository<Customer> _repository;

        public UpdateCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCustomerCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CustomerId);

            values.Name = command.Name;
            values.Surname = command.Surname;
            values.Email = command.Email;
            values.Phone = command.Phone;
            values.Job = command.Job;
            values.AddressId = command.AddressId;

            await _repository.UpdateAsync(values);
        }
    }
}
