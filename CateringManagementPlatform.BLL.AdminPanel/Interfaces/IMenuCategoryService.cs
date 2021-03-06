using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.Interfaces
{
    public interface IMenuCategoryService
    {
        Task<IEnumerable<MenuCategoryReadDto>> GetAllAsync();
        Task<MenuCategoryReadDto> GetByIdAsync(int id);
        Task<int> CreateAsync(MenuCategoryCreateDto menuCategoryCreateDto);
        Task UpdateAsync(MenuCategoryUpdateDto menuCategoryUpdateDto);
        Task DeleteAsync(int id);
        void Dispose();
    }
}
