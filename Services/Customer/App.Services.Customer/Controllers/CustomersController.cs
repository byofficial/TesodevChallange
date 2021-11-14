using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Customer.DTOs;
using App.Services.Customer.Services;
using App.Shared.ControllerBases;

namespace App.Services.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : CustomBaseController
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _customerService.GetAllAsync();
            return CreateActionResultInstance(response);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _customerService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateDto customerCreateDto)
        {
            var response = await _customerService.CreateAsync(customerCreateDto);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerUpdateDto customerUpdateDto)
        {
            var response = await _customerService.UpdateAsync(customerUpdateDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _customerService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
