using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Auth.DTO;
using CateringManagementPlatform.DAL.Entities.People;

namespace CateringManagementPlatform.BLL.Auth.Interfaces
{
    public interface IAuthService
    {
         Task<IEnumerable<AccountReadDto>> GetAllAsync();
        //Task<OrderReadDto> GetByIdAsync(int id);
        //Task<OrderReadDto> CreateAsync(OrderCreateDto orderCreateDto);
        //Task UpdateAsync(OrderUpdateDto orderUpdateDto);
        void Dispose();
    }
}
