using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using MyValidationException;

namespace CateringManagementPlatform.BLL.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }

            var tables = await _repository.Tables.GetAllAsync();
            int tableId = tables.First(t => t.NumberTable == orderCreateDto.NumberTable).Id;

            var order = new DAL.Entities.Order()
            {
                OpeningTimeCheck = DateTime.Now,
                Comment = orderCreateDto.Comment,
                StatusId = (int)StatusName.Open,
                TableId = tableId
            };
            _repository.Orders.Create(order);
            await _repository.SaveAsync();

            foreach (var orderLineCreateDto in orderCreateDto.OrderLineCreateDtos)
            {
                var orderLine = new OrderLine()
                {
                    NumberPortions = orderLineCreateDto.NumberPortions,
                    StatusId = (int)StatusName.NewOrder,
                    DishId = orderLineCreateDto.DishId,
                    OrderId = order.Id,
                };
                _repository.OrderLines.Create(orderLine);
            }
            await _repository.SaveAsync();

            return order.Id;
        }

        //public async Task<IEnumerable<OrderReadDto>> GetAllAsync()
        //{
        //    var order = await _repository.Orders.GetAllAsync();
        //    return _mapper.Map<IEnumerable<BarmanReadDto>>(barmen);
        //}

        public async Task<OrderReadDto> GetByIdAsync(int id)
        {
            var order = await _repository.Orders.GetByIdAsync(id);
            if (order == null)
            {
                throw new ValidationException("Заказ не найден", "");
            }
            var orderReadDto= _mapper.Map<OrderReadDto>(order); ;

            return orderReadDto;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
