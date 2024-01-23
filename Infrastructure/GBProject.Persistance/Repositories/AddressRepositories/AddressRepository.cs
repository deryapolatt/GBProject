using GbProject.Domain.Entities;
using GBProject.Application.Interfaces.AddressInterfaces;
using GBProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GBProject.Persistance.Repositories.AddressRepositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly GBProjectContext _context;

        public AddressRepository(GBProjectContext context)
        {
            _context = context;
        }

        public List<Address> GetAddressesWithCustomers()
        {
            var values = _context.Addresses.Include(x => x.Customer).ToList();
            return values;
        }
    }

    }