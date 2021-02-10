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

        public async Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderCreateDto, int accountId)
        {
            int userId = await GetUserId(accountId);

            orderCreateDto.WaiterId = 1;//TODO продумать установку официанта
            orderCreateDto.GuestId = userId;

            var orderReadDto = await _orderService.CreateAsync(orderCreateDto);

            await SendFromClienToDepartment(orderCreateDto.OrderLines);

            return orderReadDto;
        }

        private async Task<int> GetUserId(int accountId)
        {
            var users = await _repository.Guests.GetAllAsync();
            var userId = users.FirstOrDefault(u => u.AccountId == accountId).Id;
            return userId;
        }

        public async Task UpdateOrderAsync(OrderUpdateDto orderUpdateDto)
        {
            await _orderService.UpdateAsync(orderUpdateDto);

            await SendFromClienToDepartment(orderUpdateDto.OrderLines);
        }

        public async Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForBar()
        {
            return await GetOrderLinesForDepartment(DepartmentName.Bar);
        }

        public async Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForKitchen()
        {
            return await GetOrderLinesForDepartment(DepartmentName.Kitchen);
        }

        public async Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForWaiter()
        {
            var orderLines = await _repository.OrderLines.GetAllAsync();
            var orderLinesForWaiter = orderLines.Where(ol =>
                ol.Order.StatusOrderId == (int)StatusNameOrder.Open
                && (ol.StatusOrderLineId == (int)StatusNameOrderLine.OrderIsReady
                || ol.StatusOrderLineId == (int)StatusNameOrderLine.Ordering)
            );
            return _mapper.Map<IEnumerable<OrderLineReadDto>>(orderLinesForWaiter);
        }

        public async Task<OrderReadDto> GetOrderForGuest(int accountId)
        {
            int userId = await GetUserId(accountId);

            var order = await _repository.Orders.GetAllAsync();

            var orderForUser = order.FirstOrDefault(o => o.GuestId == userId && o.StatusOrderId == (int)StatusNameOrder.Open);

            var orderReadDto = _mapper.Map<OrderReadDto>(orderForUser);
            if (orderForUser != null)
            {
                var guest = await _repository.Guests.GetByIdAsync(orderForUser.GuestId);
                orderReadDto.AccountId = guest.AccountId.ToString();
            }
            return orderReadDto;
        }

        private async Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForDepartment(DepartmentName departmentName)
        {
            var orderLines = await _repository.OrderLines.GetAllAsync();
            var orderLinesForDepartment = orderLines.Where(ol =>
                ol.Order.StatusOrderId == (int)StatusNameOrder.Open
                && ol.Dish.DepartmentId == (int)departmentName
                && (ol.StatusOrderLineId == (int)StatusNameOrderLine.NewOrder
                || ol.StatusOrderLineId == (int)StatusNameOrderLine.WorkOrder)
            );
            return _mapper.Map<IEnumerable<OrderLineReadDto>>(orderLinesForDepartment);
        }

        private async Task SendFromClienToDepartment(ICollection<OrderLineCreateDto> orderLines)
        {
            bool sendKitchen = false;
            bool sendBar = false;

            foreach (var orderLine in orderLines)
            {
                var dish = await _repository.Dishes.GetByIdAsync(orderLine.DishId);

                if (dish.DepartmentId == (int)DepartmentName.Bar)
                {
                    sendBar = true;
                }

                if (dish.DepartmentId == (int)DepartmentName.Kitchen)
                {
                    sendKitchen = true;
                }
            }

            if (sendBar)
            {
                await SendFromClienToBar();
            }

            if (sendKitchen)
            {
                await SendFromClienToKitchen();
            }
        }

        private async Task SendFromClienToBar()
        {
            var orderLinesForBar = await GetOrderLinesForDepartment(DepartmentName.Bar);

            await _hubContext.Clients.All.SendAsync("sentFromClienToBar", orderLinesForBar);
        }

        private async Task SendFromClienToKitchen()
        {
            var orderLinesForKitchen = await GetOrderLinesForDepartment(DepartmentName.Kitchen);

            await _hubContext.Clients.All.SendAsync("sentFromClienToKitchen", orderLinesForKitchen);
        }

        public async Task<OrderLineReadDto> UpdateOrderLineAsync(OrderLineUpdateDto orderLineUpdateDto)
        {
            OrderLine orderLine = await UpdateStatusOrderLine(orderLineUpdateDto);

            var order = await _repository.Orders.GetByIdAsync(orderLine.OrderId);

            await _hubContext.Clients.All.SendAsync("sentToClien", _mapper.Map<OrderReadDto>(order));

            if (orderLine.StatusOrderLineId == (int)StatusNameOrderLine.OrderIsReady)
            {
                var orderLineForWaiter = await GetOrderLinesForWaiter();
                await _hubContext.Clients.All.SendAsync("sentToWaiter", orderLineForWaiter);
            }

            return _mapper.Map<OrderLineReadDto>(orderLine);
        }

        private async Task<OrderLine> UpdateStatusOrderLine(OrderLineUpdateDto orderLineUpdateDto)
        {
            var orderLine = await _repository.OrderLines.GetByIdAsync(orderLineUpdateDto.Id);
            orderLine.StatusOrderLine = null;

            switch (orderLine.StatusOrderLineId)
            {
                case (int)StatusNameOrderLine.NewOrder:
                    orderLine.StatusOrderLineId = (int)StatusNameOrderLine.WorkOrder;
                    break;
                case (int)StatusNameOrderLine.WorkOrder:
                    orderLine.StatusOrderLineId = (int)StatusNameOrderLine.OrderIsReady;
                    break;
                case (int)StatusNameOrderLine.OrderIsReady:
                    orderLine.StatusOrderLineId = (int)StatusNameOrderLine.Ordering;
                    break;
                case (int)StatusNameOrderLine.Ordering:
                    orderLine.StatusOrderLineId = (int)StatusNameOrderLine.OrderFiled;
                    break;
            }

            _repository.OrderLines.Update(orderLine);
            await _repository.SaveAsync();

            orderLine = await _repository.OrderLines.GetByIdAsync(orderLineUpdateDto.Id);
            return orderLine;
        }


    }
}
