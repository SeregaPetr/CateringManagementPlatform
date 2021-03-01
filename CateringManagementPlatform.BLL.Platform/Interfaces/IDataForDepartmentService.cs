using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;
using CateringManagementPlatform.BLL.Platform.DTO.TableInfoDtos;

namespace CateringManagementPlatform.BLL.Platform.Interfaces
{
    public interface IDataForDepartmentService
    {
        Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForBarAsync();
        Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForKitchenAsync();
        Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForWaiterAsync();
        Task<IEnumerable<OrderReadDto>> GetUnpaidOrdersAsync();
        Task<IEnumerable<TableInfoReadDto>> GetAllTablesInfoAsync();
        Task<OrderReadDto> GetOrderForGuestAsync(int accountId);

        Task FreeTable(int tableId);
        Task UpdateOrderLineAsync(OrderLineUpdateDto orderLineUpdateDto);
        Task ConfirOrderAsync(OrderCreateDto orderCreateDto, int accountId);
        Task PaymentAsync(OrderUpdateDto orderUpdateDto, int accountId);
        Task ConfirmPaymentAsync(int orderId);

        void Dispose();
    }
}
