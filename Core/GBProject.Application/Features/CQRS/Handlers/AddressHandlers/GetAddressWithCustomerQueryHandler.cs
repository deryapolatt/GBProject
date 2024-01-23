using GBProject.Application.Features.CQRS.Results.AddressResults;
using GBProject.Application.Interfaces.AddressInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBProject.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressWithCustomerQueryHandler
    {
        private readonly IAddressRepository _repository;

        public GetAddressWithCustomerQueryHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public List<GetAddressWithCustomerQueryResult> Handle()
        {
            var values = _repository.GetAddressesWithCustomers();
            return values.Select(x => new GetAddressWithCustomerQueryResult
            {

                CustomerName = x.Customer.Name,
                AddressId = x.AddressId,
                Description = x.Description,
                CustomerId = x.CustomerId


            }).ToList();
        }
    }
}
