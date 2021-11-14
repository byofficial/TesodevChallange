using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Order.DTOs;
using App.Services.Order.Services;
using App.Shared.ControllerBases;

namespace App.Services.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _orderService.GetAllAsync();
            return CreateActionResultInstance(response);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _orderService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _orderService.GetAllByUserIdAsync(userId);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDto orderCreateDto)
        {
            var response = await _orderService.CreateAsync(orderCreateDto);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderUpdateDto orderUpdateDto)
        {
            var response = await _orderService.UpdateAsync(orderUpdateDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _orderService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
