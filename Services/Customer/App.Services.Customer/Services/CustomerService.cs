using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Customer.DTOs;
using App.Services.Customer.Settings;
using App.Shared.DTOs;
using AutoMapper;
using MongoDB.Driver;

namespace App.Services.Customer.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly IMongoCollection<Models.Customer> _customerCollection;
        private readonly IMapper _mapper;

        public CustomerService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _customerCollection = database.GetCollection<Models.Customer>(databaseSettings.CustomerCollectionName);

            _mapper = mapper;
        }
        public async Task<Response<List<CustomerDto>>> GetAllAsync()
        {
            var customers = await _customerCollection.Find(customer => true).ToListAsync();
            if (!customers.Any())
            {
                customers = new List<Models.Customer>();
            }

            return Response<List<CustomerDto>>.Success(_mapper.Map<List<CustomerDto>>(customers), 200);
        }

        public async Task<Response<CustomerDto>> GetByIdAsync(string id)
        {
            var customer = await _customerCollection.Find<Models.Customer>(x => x.Id == id).FirstOrDefaultAsync();
            return customer == null ? Response<CustomerDto>.Fail("Customer Not Found", 404) : Response<CustomerDto>.Success(_mapper.Map<CustomerDto>(customer), 200);
        }

        public async Task<Response<CustomerDto>> CreateAsync(CustomerCreateDto customerCreateDto)
        {
            var newCustomer = _mapper.Map<Models.Customer>(customerCreateDto);
            newCustomer.CreatedAt = DateTime.Now;
            await _customerCollection.InsertOneAsync(newCustomer);

            return Response<CustomerDto>.Success(_mapper.Map<CustomerDto>(newCustomer), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(CustomerUpdateDto customerUpdateDto)
        {
            var updateCustomer = _mapper.Map<Models.Customer>(customerUpdateDto);
            updateCustomer.UpdatedAt = DateTime.Now;
            var result =
                await _customerCollection.FindOneAndReplaceAsync(x => x.Id == customerUpdateDto.Id, updateCustomer);

            return result == null ? Response<NoContent>.Fail("Customer Not Found", 404) : Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _customerCollection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Customer not found", 404);
        }
    }
}
