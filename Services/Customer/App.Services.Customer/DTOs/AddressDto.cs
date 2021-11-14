using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Customer.DTOs
{
    public class AddressDto
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CityCode { get; set; }
    }
}
