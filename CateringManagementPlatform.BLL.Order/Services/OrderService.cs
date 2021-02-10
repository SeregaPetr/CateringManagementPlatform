using System;
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

        public async Task<OrderReadDto> CreateAsync(OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }

            var tables = await _repository.Tables.GetAllAsync();
            int tableId = tables.First(t => t.NumberTable == orderCreateDto.NumberTable).Id;

            var orderTemp = new DAL.Entities.Order()
            {
                OpeningTimeCheck = DateTime.Now,
                StatusOrderId = (int)StatusNameOrder.Open,
                TableId = tableId,
                GuestId = orderCreateDto.GuestId,
                WaiterId = orderCreateDto.WaiterId
            };
            _repository.Orders.Create(orderTemp);
            await _repository.SaveAsync();

            foreach (var orderLineCreateDto in orderCreateDto.OrderLines)
            {
                var orderLine = new OrderLine()
                {
                    NumberPortions = orderLineCreateDto.CountPortions,
                    StatusOrderLineId = (int)StatusNameOrderLine.NewOrder,
                    DishId = orderLineCreateDto.DishId,
                    OrderId = orderTemp.Id,
                };
                _repository.OrderLines.Create(orderLine);
            }
            await _repository.SaveAsync();

            var order = await _repository.Orders.GetByIdAsync(orderTemp.Id);
            var orderReadDto = _mapper.Map<OrderReadDto>(order);

            return orderReadDto;
        }

        public async Task<OrderReadDto> GetByIdAsync(int id)
        {
            var order = await _repository.Orders.GetByIdAsync(id);
            if (order == null)
            {
                throw new ValidationException("Заказ не найден", "");
            }
            var orderReadDto = _mapper.Map<OrderReadDto>(order);

            return orderReadDto;
        }

        public async Task UpdateAsync(OrderUpdateDto orderUpdateDto)
        {
            var order = await _repository.Orders.GetByIdAsync(orderUpdateDto.Id);
            if (order == null)
            {
                throw new ValidationException("Заказ не найден", "");
            }

            foreach (var orderLineCreateDto in orderUpdateDto.OrderLines)
            {
                var orderLine = new OrderLine()
                {
                    NumberPortions = orderLineCreateDto.CountPortions,
                    StatusOrderLineId = (int)StatusNameOrderLine.NewOrder,
                    DishId = orderLineCreateDto.DishId,
                    OrderId = order.Id,
                };
                _repository.OrderLines.Create(orderLine);
            }
            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
