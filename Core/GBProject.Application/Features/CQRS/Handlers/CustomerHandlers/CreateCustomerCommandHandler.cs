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
    public class CreateCustomerCommandHandler
    {

        private readonly IRepository<Customer> _repository;

        public CreateCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCustomerCommand command)
        {
            await _repository.CreateAsync(new Customer
            {
                Name = command.Name,
                Surname = command.Surname,
                Email = command.Email,
                Phone = command.Phone,
                Job = command.Job,
                AddressId = command.AddressId

            });
        }
    }
}
