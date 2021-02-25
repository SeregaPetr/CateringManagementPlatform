using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;

namespace CateringManagementPlatform.BLL.Order.Interfaces
{
    public interface IOrderService
    {
        Task<OrderReadDto> GetByIdAsync(int id);
        Task<OrderReadDto> CreateAsync(OrderCreateDto orderCreateDto, int numberTable);
        Task UpdateAsync(OrderUpdateDto orderUpdateDto);
        void Dispose();
    }
}
