using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Order.DTOs;
using App.Services.Order.Settings;
using App.Shared.DTOs;
using AutoMapper;
using MongoDB.Driver;

namespace App.Services.Order.Services
{
    public class OrderService:IOrderService
    {
        private readonly IMongoCollection<Models.Order> _orderCollection;
        private readonly IMapper _mapper;

        public OrderService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _orderCollection = database.GetCollection<Models.Order>(databaseSettings.OrderCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<List<OrderDto>>> GetAllAsync()
        {
            var orders = await _orderCollection.Find(order => true).ToListAsync();
            if (!orders.Any())
            {
                orders = new List<Models.Order>();
            }

            return Response<List<OrderDto>>.Success(_mapper.Map<List<OrderDto>>(orders), 200);
        }

        public async Task<Response<OrderDto>> GetByIdAsync(string id)
        {
            var order = await _orderCollection.Find<Models.Order>(x => x.Id == id).FirstOrDefaultAsync();
            return order == null ? Response<OrderDto>.Fail("Order Not Found", 404) : Response<OrderDto>.Success(_mapper.Map<OrderDto>(order), 200);
        }

        public async Task<Response<List<OrderDto>>> GetAllByUserIdAsync(string userId)
        {
            var orders = await _orderCollection.Find<Models.Order>(x => x.CustomerId == userId).ToListAsync();

            return Response<List<OrderDto>>.Success(_mapper.Map<List<OrderDto>>(orders), 200);

        }

        public async Task<Response<OrderDto>> CreateAsync(OrderCreateDto orderCreateDto)
        {
            var newOrder = _mapper.Map<Models.Order>(orderCreateDto);
            newOrder.CreatedAt = DateTime.Now;
            await _orderCollection.InsertOneAsync(newOrder);

            return Response<OrderDto>.Success(_mapper.Map<OrderDto>(newOrder), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(OrderUpdateDto orderUpdateDto)
        {
            var updateOrder = _mapper.Map<Models.Order>(orderUpdateDto);
            updateOrder.UpdatedAt = DateTime.Now;
            var result =
                await _orderCollection.FindOneAndReplaceAsync(x => x.Id == orderUpdateDto.Id, updateOrder);

            return result == null ? Response<NoContent>.Fail("Order Not Found", 404) : Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _orderCollection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Order not found", 404);
        }
    }
}
