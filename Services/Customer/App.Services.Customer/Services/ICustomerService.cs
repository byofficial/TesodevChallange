using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Customer.DTOs;
using App.Shared.DTOs;

namespace App.Services.Customer.Services
{
    public interface ICustomerService
    {
        Task<Response<List<CustomerDto>>> GetAllAsync();
        Task<Response<CustomerDto>> GetByIdAsync(string id);
        Task<Response<CustomerDto>> CreateAsync(CustomerCreateDto customerCreateDto);
        Task<Response<NoContent>> UpdateAsync(CustomerUpdateDto customerUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
