using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;

namespace CateringManagementPlatform.BLL.Platform.Interfaces
{
    public interface IDataForDepartmentService
    {
        Task<OrderLineReadDto> UpdateOrderLineAsync(OrderLineUpdateDto orderLineUpdateDto);
        Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderCreateDto, int accountId);
        Task UpdateOrderAsync(OrderUpdateDto orderUpdateDto);
        Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForWaiter();
        Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForBar();
        Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForKitchen();
        Task<OrderReadDto> GetOrderForGuest(int accountId);
    }
}
