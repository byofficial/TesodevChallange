using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Order.DTOs;
using App.Shared.DTOs;

namespace App.Services.Order.Services
{
    public interface IOrderService
    {
        Task<Response<List<OrderDto>>> GetAllAsync();
        Task<Response<OrderDto>> GetByIdAsync(string id);
        Task<Response<List<OrderDto>>> GetAllByUserIdAsync(string userId);
        Task<Response<OrderDto>> CreateAsync(OrderCreateDto orderCreateDto);
        Task<Response<NoContent>> UpdateAsync(OrderUpdateDto orderUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
