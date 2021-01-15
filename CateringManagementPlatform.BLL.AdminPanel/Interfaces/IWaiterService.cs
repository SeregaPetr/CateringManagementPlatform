using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.EmployeesDto.WaiterDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.Interfaces
{
    public interface IWaiterService
    {
        Task<IEnumerable<WaiterReadDto>> GetAllAsync();
        Task<WaiterReadDto> GetByIdAsync(int id);
        Task<int> CreateAsync(WaiterCreateDto waiterCreateDto);
        Task UpdateAsync(WaiterUpdateDto waiterUpdateDto);
        Task DeleteAsync(int id);
        void Dispose();
    }
}
