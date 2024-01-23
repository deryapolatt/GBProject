using GbProject.Domain.Entities;
using GBProject.Application.Features.CQRS.Results.CustomerResults;
using GBProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GBProject.Application.Features.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerQueryHandler
    {
        private readonly IRepository<Customer> _repository;
        public GetCustomerQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;

        }
        public async Task<List<GetCustomerQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCustomerQueryResult
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone = x.Phone,
                Job = x.Job,
                AddressId = x.AddressId

            }).ToList();


        }
    }
}