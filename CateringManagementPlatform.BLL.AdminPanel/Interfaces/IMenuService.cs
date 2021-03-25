using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.Interfaces
{
    public interface IMenuService
    {
        Task<MenuReadDto> GetActiveMenuAsync();
        Task<IEnumerable<MenuReadDto>> GetAllAsync();
        Task<MenuReadDto> GetByIdAsync(int id);
        Task<int> CreateAsync(MenuCreateDto menuCreateDto);
        Task UpdateAsync(MenuUpdateDto menuUpdateDto);
        Task DeleteAsync(int id);
        Task MakeActiveMenuAsync(MenuUpdateDto menuUpdateDto);
        Task CreateMenuAsync(MenuUpdateDto menuUpdateDto);
        void Dispose();
    }
}
