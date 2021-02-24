using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DishDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.Interfaces
{
    public interface IDishService
    {
        Task<IEnumerable<DishReadDto>> GetAllAsync();
        Task<DishReadDto> GetByIdAsync(int id);
        Task<int> CreateAsync(DishCreateDto dishCreateDto);
        Task UpdateAsync(DishUpdateDto dishUpdateDto);
        Task DeleteAsync(int id);
        void Dispose();
    }
}
