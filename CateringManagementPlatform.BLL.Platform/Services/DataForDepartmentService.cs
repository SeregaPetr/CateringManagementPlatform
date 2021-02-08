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

        public async Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            var orderReadDto = await _orderService.CreateAsync(orderCreateDto);

            await SendFromClienToDepartment(orderCreateDto.OrderLines);

            return orderReadDto;
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

        private async Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForDepartment(DepartmentName departmentName)
        {
            var orderLines = await _repository.OrderLines.GetAllAsync();
            var orderLinesForDepartment = orderLines.Where(ol =>
                ol.Order.StatusOrderId == (int)StatusNameOrder.Open
                && ol.Dish.DepartmentId == (int)departmentName
                && (ol.StatusOrderLineId == (int)StatusNameOrderLine.NewOrder
                || ol.StatusOrderLineId == (int)StatusNameOrderLine.WorkOrder)
            );
            return _mapper.Map<List<OrderLineReadDto>>(orderLinesForDepartment);
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


    }
}
