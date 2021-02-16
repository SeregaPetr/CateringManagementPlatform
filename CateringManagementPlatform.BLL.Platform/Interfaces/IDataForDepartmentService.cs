using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;

namespace CateringManagementPlatform.BLL.Platform.Interfaces
{
    public interface IDataForDepartmentService
    {
        Task UpdateOrderLineAsync(OrderLineUpdateDto orderLineUpdateDto);
        Task ConfirOrderAsync(OrderCreateDto orderCreateDto, int accountId);
        Task ConfirmPaymentAsync(int orderId);
        Task PaymentAsync(OrderUpdateDto orderUpdateDto, int accountId);
        Task<IEnumerable<OrderReadDto>> GetUnpaidOrdersAsync();
        Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForWaiterAsync();
        Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForBarAsync();
        Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForKitchenAsync();
        Task<OrderReadDto> GetOrderForGuestAsync(int accountId);
        void Dispose();
    }
}
