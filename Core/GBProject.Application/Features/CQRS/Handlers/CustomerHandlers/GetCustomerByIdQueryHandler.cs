using GbProject.Domain.Entities;
using GBProject.Application.Features.CQRS.Queries.CustomerQueries;
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
    public class GetCustomerByIdQueryHandler
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomerByIdQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCustomerByIdQueryResult
            {
                CustomerId= value.CustomerId,
                Name = value.Name,
                Surname = value.Surname,
                Email = value.Email,
                Phone = value.Phone,
                Job = value.Job,
                AddressId = value.AddressId

            };
        }
    }
}
