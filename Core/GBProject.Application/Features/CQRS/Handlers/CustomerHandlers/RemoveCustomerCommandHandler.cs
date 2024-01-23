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
    public class RemoveCustomerCommandHandler
    {

        private readonly IRepository<Customer> _repository;

        public RemoveCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCustomerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
