using GBProject.Application.Features.CQRS.Results.AddressResults;
using GBProject.Application.Features.CQRS.Results.CustomerResults;
using GBProject.Application.Interfaces.AddressInterfaces;
using GBProject.Application.Interfaces.CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBProject.Application.Features.CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerWithAddressQueryHandler
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerWithAddressQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public List<GetCustomerWithAddressQueryResult> Handle()
        {
            var values = _repository.GetCustomersWithAddresses();
            return values.Select(x => new GetCustomerWithAddressQueryResult
            {

                AddressDescription = x.Address.Description,
                                
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
