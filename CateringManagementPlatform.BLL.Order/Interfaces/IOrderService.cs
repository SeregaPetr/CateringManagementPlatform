using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;

namespace CateringManagementPlatform.BLL.Order.Interfaces
{
    public interface IOrderService
    {
       // Task<IEnumerable<OrderReadDto>> GetAllAsync();
        Task<OrderReadDto> GetByIdAsync(int id);
        Task<int> CreateAsync(OrderCreateDto orderCreateDto);
        Task UpdateAsync(OrderUpdateDto orderUpdateDto);
        void Dispose();
    }
}
