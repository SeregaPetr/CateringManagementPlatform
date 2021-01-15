using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.EmployeesDto.ChefDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.Interfaces
{
    public interface IChefService
    {
        Task<IEnumerable<ChefReadDto>> GetAllAsync();
        Task<ChefReadDto> GetByIdAsync(int id);
        Task<int> CreateAsync(ChefCreateDto chefCreateDto);
        Task UpdateAsync(ChefUpdateDto chefUpdateDto);
        Task DeleteAsync(int id);
        void Dispose();
    }
}
