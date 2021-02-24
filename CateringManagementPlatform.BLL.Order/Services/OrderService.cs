using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;
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

        public async Task<OrderReadDto> CreateAsync(OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }

            var orderTemp = await CreateOrderAsync(orderCreateDto);

            await CreateOrderLinesAsync(orderCreateDto.OrderLines, orderTemp.Id);

            var order = await _repository.Orders.GetByIdAsync(orderTemp.Id);

            return _mapper.Map<OrderReadDto>(order);
        }

        public async Task UpdateAsync(OrderUpdateDto orderUpdateDto)
        {
            await UpdateOrderAsync(orderUpdateDto);

            await CreateOrderLinesAsync(orderUpdateDto.OrderLines, orderUpdateDto.Id);
        }

        private async Task<DAL.Entities.Order> CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            var tables = await _repository.Tables.GetAllAsync();
            var table = tables.First(t => t.NumberTable == orderCreateDto.NumberTable);

            var orderTemp = new DAL.Entities.Order()
            {
                CheckOpeningTime = DateTime.Now,
                StatusOrderId = (int)NameStatusOrder.Open,
                TableId = table.Id,
                GuestId = orderCreateDto.GuestId.Value,
                WaiterId = orderCreateDto.WaiterId.Value
            };
            _repository.Orders.Create(orderTemp);

            table.IsReservation = true;
            table.NumberGuests = orderCreateDto.NumberGuests;
            _repository.Tables.Update(table);

            await _repository.SaveAsync();

            return orderTemp;
        }

        private async Task<DAL.Entities.Order> UpdateOrderAsync(OrderUpdateDto orderUpdateDto)
        {
            var order = await _repository.Orders.GetByIdAsync(orderUpdateDto.Id);

            if (order == null)
            {
                throw new ValidationException("Заказ не найден", "");
            }

            order.CheckClosingTime = orderUpdateDto.CheckClosingTime;
            order.StatusOrderId = orderUpdateDto.StatusOrderId;
            order.PaymentTypeId = orderUpdateDto.PaymentTypeId;

            _repository.Orders.Update(order);
            await _repository.SaveAsync();
            return order;
        }

        private async Task CreateOrderLinesAsync(ICollection<OrderLineCreateDto> orderLines, int orderId)
        {
            foreach (var orderLineCreateDto in orderLines)
            {
                var orderLine = new OrderLine()
                {
                    CountPortions = orderLineCreateDto.CountPortions,
                    StatusOrderLineId = (int)NameStatusOrderLine.NewOrder,
                    DishId = orderLineCreateDto.DishId,
                    OrderId = orderId
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
