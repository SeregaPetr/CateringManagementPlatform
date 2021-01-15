using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.EmployeesDto.BarmanDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.Interfaces
{
    public interface IBarmanService
    {
        Task<IEnumerable<BarmanReadDto>> GetAllAsync();
        Task<BarmanReadDto> GetByIdAsync(int id);
        Task<int> CreateAsync(BarmanCreateDto barmanCreateDto);
        Task UpdateAsync(BarmanUpdateDto barmanUpdateDto);
        Task DeleteAsync(int id);
        void Dispose();
    }
}
