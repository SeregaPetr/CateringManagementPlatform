using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.MenuDtos;

namespace CateringManagementPlatform.BLL.Order.Interfaces
{
    public interface IMenuService
    {
        Task<MenuReadDto> GetAsync();
      //  Task<IEnumerable<MenuReadDto>> GetAllAsync();
        void Dispose();
    }
}
