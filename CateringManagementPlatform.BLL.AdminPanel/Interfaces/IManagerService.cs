using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.EmployeesDto.ManagerDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.Interfaces
{
    public interface IManagerService
    {
        Task<IEnumerable<ManagerReadDto>> GetAllAsync();
        Task<ManagerReadDto> GetByIdAsync(int id);
        Task<int> CreateAsync(ManagerCreateDto managerCreateDto);
        Task UpdateAsync(ManagerUpdateDto managerUpdateDto);
        Task DeleteAsync(int id);
        void Dispose();
    }
}
