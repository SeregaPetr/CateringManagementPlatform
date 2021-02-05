using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;

namespace CateringManagementPlatform.API.Interfaces
{
    public interface IPlatformHub
    {
        Task SendToClient(OrderReadDto orderReadDto);
        Task SendToBar(OrderReadDto orderReadDto);
        Task SendToKitchen(OrderReadDto orderReadDto);
        Task SendToWaiters(OrderReadDto orderReadDto);
    }
}
