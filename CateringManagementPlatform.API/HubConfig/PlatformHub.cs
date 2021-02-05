using CateringManagementPlatform.API.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace CateringManagementPlatform.API.HubConfig
{
    public class PlatformHub : Hub<IPlatformHub>
    {
        //public async Task CreateOrder(OrderReadDto orderReadDto)
        //{
        //    await Clients.All.SendToClient(orderReadDto);
        //}
    }
}
