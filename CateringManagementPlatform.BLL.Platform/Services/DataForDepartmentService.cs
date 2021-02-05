using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;
using CateringManagementPlatform.BLL.Order.Interfaces;
using CateringManagementPlatform.BLL.Platform.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.Platform.Services
{
    public class DataForDepartmentService : IDataForDepartmentService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public DataForDepartmentService(IUnitOfWork repository, IMapper mapper, IOrderService orderService)
        {
            _repository = repository;
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            return await _orderService.CreateAsync(orderCreateDto);
        }

        public async Task<List<OrderLineReadDto>> GetOrderLinesForBar()
        {
            var orderLines = await _repository.OrderLines.GetAllAsync();
            var orderLinesForBar = orderLines.Where(ol =>
                ol.Order.StatusId == (int)StatusName.Open
                && ol.Dish.DepartmentId == (int)DepartmentName.Bar
                && ol.StatusId == (int)StatusName.NewOrder
                && ol.StatusId==(int) StatusName.WorkOrder
            );

            return _mapper.Map<List<OrderLineReadDto>>(orderLinesForBar);
        }

    }
}
