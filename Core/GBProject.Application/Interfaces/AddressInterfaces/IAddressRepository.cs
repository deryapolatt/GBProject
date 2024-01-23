using GbProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBProject.Application.Interfaces.AddressInterfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAddressesWithCustomers();
    }
}
