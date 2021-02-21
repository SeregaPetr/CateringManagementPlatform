using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;
using CateringManagementPlatform.BLL.Order.Interfaces;
using CateringManagementPlatform.BLL.Platform.HubConfig;
using CateringManagementPlatform.BLL.Platform.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace CateringManagementPlatform.BLL.Platform.Services
{
    public class DataForDepartmentService : IDataForDepartmentService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IHubContext<PlatformHub> _hubContext;

        public DataForDepartmentService(IUnitOfWork repository, IMapper mapper, IOrderService orderService, IHubContext<PlatformHub> hubContext)
        {
            _repository = repository;
            _mapper = mapper;
            _orderService = orderService;
            _hubContext = hubContext;
        }

        public async Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForBarAsync()
        {
            return await GetOrderLinesForDepartmentAsync(DepartmentName.Bar);
        }

        public async Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForKitchenAsync()
        {
            return await GetOrderLinesForDepartmentAsync(DepartmentName.Kitchen);
        }

        public async Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForWaiterAsync()
        {
            return await GetOrderLinesForDepartmentAsync(DepartmentName.Waiters);
        }

        private async Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForDepartmentAsync(DepartmentName departmentName)
        {
            var orderLines = await _repository.OrderLines.GetAllAsync();
            IEnumerable<OrderLine> orderLinesForDepartment = new List<OrderLine>();

            if (departmentName == DepartmentName.Kitchen || departmentName == DepartmentName.Bar)
            {
                orderLinesForDepartment = orderLines.Where(ol =>
                    ol.Dish.DepartmentId == (int)departmentName
                    && (ol.StatusOrderLineId == (int)NameStatusOrderLine.NewOrder
                    || ol.StatusOrderLineId == (int)NameStatusOrderLine.WorkOrder)
                );
            }
            else if (departmentName == DepartmentName.Waiters)
            {
                orderLinesForDepartment = orderLines.Where(ol =>
                    (ol.StatusOrderLineId == (int)NameStatusOrderLine.OrderIsReady
                    || ol.StatusOrderLineId == (int)NameStatusOrderLine.Ordering)
                );
            }
            return _mapper.Map<IEnumerable<OrderLineReadDto>>(orderLinesForDepartment);
        }

        public async Task<IEnumerable<OrderReadDto>> GetUnpaidOrdersAsync()
        {
            return await GetUnpaidOrderAsync();
        }

        public async Task<OrderReadDto> GetOrderForGuestAsync(int accountId)
        {
            int userId = await GetUserIdAsync(accountId);

            var orderForUser = await OrderForGuestAsync(userId);

            OrderReadDto orderReadDto = _mapper.Map<OrderReadDto>(orderForUser);

            return orderReadDto ?? new OrderReadDto();
        }

        public async Task UpdateOrderLineAsync(OrderLineUpdateDto orderLineUpdateDto)
        {
            OrderLine orderLine = await UpdateStatusOrderLineAsync(orderLineUpdateDto);

            await SendToClienAsync(orderLine.OrderId);

            if (orderLine.Dish.DepartmentId == (int)DepartmentName.Bar &&
               (orderLine.StatusOrderLineId == (int)NameStatusOrderLine.WorkOrder ||
                orderLine.StatusOrderLineId == (int)NameStatusOrderLine.OrderIsReady))
            {
                await SendToBarAsync();
            }
            else if (orderLine.Dish.DepartmentId == (int)DepartmentName.Kitchen &&
                    (orderLine.StatusOrderLineId == (int)NameStatusOrderLine.WorkOrder ||
                     orderLine.StatusOrderLineId == (int)NameStatusOrderLine.OrderIsReady))
            {
                await SendToKitchenAsync();
            }
            if (orderLine.StatusOrderLineId == (int)NameStatusOrderLine.OrderIsReady ||
                orderLine.StatusOrderLineId == (int)NameStatusOrderLine.Ordering ||
                orderLine.StatusOrderLineId == (int)NameStatusOrderLine.OrderFiled)
            {
                await SendToWaiterAsync();
            }
        }

        private async Task SendFromClienToDepartmentAsync(IEnumerable<int> departmentsId)
        {
            foreach (var dpartmentId in departmentsId)
            {
                if (dpartmentId == (int)DepartmentName.Bar)
                {
                    await SendToBarAsync();
                }

                if (dpartmentId == (int)DepartmentName.Kitchen)
                {
                    await SendToKitchenAsync();
                }
            }
        }

        private async Task SendToBarAsync()
        {
            var orderLinesForBar = await GetOrderLinesForBarAsync();
            await _hubContext.Clients.All.SendAsync("sentToBar", orderLinesForBar);
        }

        private async Task SendToKitchenAsync()
        {
            var orderLinesForKitchen = await GetOrderLinesForKitchenAsync();
            await _hubContext.Clients.All.SendAsync("sentToKitchen", orderLinesForKitchen);
        }

        private async Task SendToClienAsync(int orderId)
        {
            var order = await _repository.Orders.GetByIdAsync(orderId);
            await _hubContext.Clients.All.SendAsync("sentToClien", _mapper.Map<OrderReadDto>(order));
        }

        private async Task SendToWaiterAsync()
        {
            var orderLineForWaiter = await GetOrderLinesForWaiterAsync();
            await _hubContext.Clients.All.SendAsync("sentToWaiter", orderLineForWaiter);
        }

        private async Task SendOrdersForWaiterAsync()
        {
            IEnumerable<OrderReadDto> unpaidOrders = await GetUnpaidOrderAsync();
            await _hubContext.Clients.All.SendAsync("sentOrdersForWaiter", unpaidOrders);
           // await _hubContext.Clients.Client(connectionId).SendAsync("sentOrdersForWaiter", unpaidOrders);
        }

        private async Task<IEnumerable<OrderReadDto>> GetUnpaidOrderAsync()
        {
            var orders = await _repository.Orders.GetAllAsync();

            var unpaidOrder = orders.Where(o =>
            o.StatusOrderId == (int)NameStatusOrder.Open || o.StatusOrderId == (int)NameStatusOrder.Payment);

            return _mapper.Map<IEnumerable<OrderReadDto>>(unpaidOrder);
        }

        private async Task<OrderLine> UpdateStatusOrderLineAsync(OrderLineUpdateDto orderLineUpdateDto)
        {
            var orderLine = await _repository.OrderLines.GetByIdAsync(orderLineUpdateDto.Id);
            orderLine.StatusOrderLine = null;

            switch (orderLine.StatusOrderLineId)
            {
                case (int)NameStatusOrderLine.NewOrder:
                    orderLine.StatusOrderLineId = (int)NameStatusOrderLine.WorkOrder;
                    break;
                case (int)NameStatusOrderLine.WorkOrder:
                    orderLine.StatusOrderLineId = (int)NameStatusOrderLine.OrderIsReady;
                    break;
                case (int)NameStatusOrderLine.OrderIsReady:
                    orderLine.StatusOrderLineId = (int)NameStatusOrderLine.Ordering;
                    break;
                case (int)NameStatusOrderLine.Ordering:
                    orderLine.StatusOrderLineId = (int)NameStatusOrderLine.OrderFiled;
                    break;
            }

            _repository.OrderLines.Update(orderLine);
            await _repository.SaveAsync();

            orderLine = await _repository.OrderLines.GetByIdAsync(orderLineUpdateDto.Id);
            return orderLine;
        }

        public async Task ConfirOrderAsync(OrderCreateDto orderCreateDto, int accountId)
        {
            int userId = await GetUserIdAsync(accountId);
            var orderGuest = await OrderForGuestAsync(userId);

            if (orderGuest is null)
            {
                orderCreateDto.GuestId = userId;
                orderCreateDto.WaiterId = ChoiceWaiterAsync();

                await _orderService.CreateAsync(orderCreateDto);
            }
            else
            {
                OrderUpdateDto orderUpdateDto = new OrderUpdateDto
                {
                    Id = orderGuest.Id,
                    PaymentTypeId = orderGuest.PaymentTypeId,
                    StatusOrderId = orderGuest.StatusOrderId,
                    OrderLines = orderCreateDto.OrderLines,

                };
                await _orderService.UpdateAsync(orderUpdateDto);
            }

            var departmentsId = await DepartmentsIdToSendDataAsync(userId);

            await SendFromClienToDepartmentAsync(departmentsId);
            await SendOrdersForWaiterAsync();
        }

        public async Task PaymentAsync(OrderUpdateDto orderUpdateDto, int accountId)
        {
            int userId = await GetUserIdAsync(accountId);
            var orderGuest = await OrderForGuestAsync(userId);

            if (orderGuest != null)
            {
                OrderUpdateDto orderUpdate = new OrderUpdateDto
                {
                    Id = orderGuest.Id,
                    PaymentTypeId = orderUpdateDto.PaymentTypeId,
                    StatusOrderId = (int)NameStatusOrder.Payment,
                    OrderLines = orderUpdateDto.OrderLines
                };
                await _orderService.UpdateAsync(orderUpdate);

                await SendToClienAsync(orderGuest.Id);
                await SendOrdersForWaiterAsync();
            }
        }

        public async Task ConfirmPaymentAsync(int orderId)
        {
            var order = await _repository.Orders.GetByIdAsync(orderId);

            OrderUpdateDto orderUpdate = new OrderUpdateDto
            {
                Id = order.Id,
                PaymentTypeId = order.PaymentTypeId,
                StatusOrderId = (int)NameStatusOrder.Closed,
                CheckClosingTime = DateTime.Now
            };
            await _orderService.UpdateAsync(orderUpdate);

            await SendToClienAsync(orderId);
            await SendOrdersForWaiterAsync();
        }

        private async Task<DAL.Entities.Order> OrderForGuestAsync(int userId)
        {
            var orders = await _repository.Orders.GetAllAsync();
            var orderGuest = orders.FirstOrDefault(o => o.GuestId == userId &&
                (o.StatusOrderId == (int)NameStatusOrder.Open || o.StatusOrderId == (int)NameStatusOrder.Payment));
            return orderGuest;
        }

        private async Task<IEnumerable<int>> DepartmentsIdToSendDataAsync(int userId)
        {
            var orders = await _repository.Orders.GetAllAsync();
            var orderGuest = orders.FirstOrDefault(o => o.GuestId == userId &&
                 (o.StatusOrderId == (int)NameStatusOrder.Open || o.StatusOrderId == (int)NameStatusOrder.Payment));

            return orderGuest?.OrderLines.Select(o => o.Dish.DepartmentId).Distinct();
        }

        private int? ChoiceWaiterAsync() //TODO продумать установку официанта
        {
            return 4;
        }

        private async Task<int> GetUserIdAsync(int accountId)
        {
            var users = await _repository.Guests.GetAllAsync();
            var userId = users.FirstOrDefault(u => u.AccountId == accountId).Id;
            return userId;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
