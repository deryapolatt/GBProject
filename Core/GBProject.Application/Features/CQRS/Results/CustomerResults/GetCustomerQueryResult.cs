using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBProject.Application.Features.CQRS.Results.CustomerResults
{
    public class GetCustomerQueryResult
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Job { get; set; }
        public int AddressId { get; set; }
    }
}
