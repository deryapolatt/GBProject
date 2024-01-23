using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBProject.Application.Features.CQRS.Results.AddressResults
{
    public class GetAddressQueryResult
    {
        public int AddressId { get; set; }
        public string Description { get; set; }

        public int CustomerId { get; set; }
    }
}
