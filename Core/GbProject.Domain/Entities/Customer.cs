﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbProject.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Job { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}
