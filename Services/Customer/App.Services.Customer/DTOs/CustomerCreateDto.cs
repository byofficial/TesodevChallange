using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Customer.DTOs
{
    public class CustomerCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
    }
}
