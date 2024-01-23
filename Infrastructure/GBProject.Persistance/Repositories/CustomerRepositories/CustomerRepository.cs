using GBProject.Application.Interfaces.AddressInterfaces;
using GbProject.Domain.Entities;
using GBProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GBProject.Application.Interfaces.CustomerInterfaces;

namespace GBProject.Persistance.Repositories.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly GBProjectContext _context;

        public CustomerRepository(GBProjectContext context)
        {
            _context = context;
        }

        public List<Customer> GetCustomersWithAddresses()
        {
            var values = _context.Customers.Include(x => x.Address).ToList();
            return values;
        }
    }

}
