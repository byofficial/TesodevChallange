using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Order.DTOs
{
    public class OrderCreateDto
    {
        public string CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public AddressDto Address { get; set; }
        public ProductDto Product { get; set; }
    }
}
