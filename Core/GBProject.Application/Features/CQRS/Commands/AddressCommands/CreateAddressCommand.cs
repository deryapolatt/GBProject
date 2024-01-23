using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBProject.Application.Features.CQRS.Commands.AddressCommands
{
    public class CreateAddressCommand
    {
        public string Description { get; set; }

        public int CustomerId { get; set; }
    }
}
