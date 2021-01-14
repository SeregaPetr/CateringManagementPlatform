using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.DTO.DishDtos;

namespace CateringManagementPlatform.BLL.Interfaces
{
    public interface IDishService
    {
        Task<IEnumerable<DishReadDto>> GetAllAsync();
        Task<DishReadDto> GetByIdAsync(int id);
        Task<int> CreateAsync(DishCreateDto dishCreateDto);
        Task UpdateAsync(DishUpdateDto dishUpdateDto);
        void Dispose();
    }
}
