using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;

namespace CateringManagementPlatform.BLL.Platform.Interfaces
{
    public interface IDataForDepartmentService
    {
        Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderCreateDto);
        Task UpdateOrderAsync(OrderUpdateDto orderUpdateDto);
        Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForBar();
        Task<IEnumerable<OrderLineReadDto>> GetOrderLinesForKitchen();




        //Open = 1,       //счет открыт     ->user
        //Closed,         //счет закрыт     ->user!!!
        //NewOrder,       //новый заказ     ->bar, Kitchen, user
        //WorkOrder,      //заказ в работе  ->bar, Kitchen, user
        //OrderIsReady,   //заказ готов     ->waiters, user
        //Ordering,       //подача заказа   ->waiters, user
        //OrderFiled,     //заказ подан     ->user, user
        //BillPaid

        //Bar = 1,
        //Kitchen,
        //Waiters,
        //Managers
    }
}
