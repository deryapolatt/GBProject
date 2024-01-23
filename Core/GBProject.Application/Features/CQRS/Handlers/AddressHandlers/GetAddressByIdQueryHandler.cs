using GbProject.Domain.Entities;
using GBProject.Application.Features.CQRS.Queries.AddressQueries;
using GBProject.Application.Features.CQRS.Results.AddressResults;
using GBProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GBProject.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = value.AddressId,
                Description = value.Description,
                CustomerId = value.CustomerId

            };
        }
    }
}
