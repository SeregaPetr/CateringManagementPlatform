using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.DTO.PeopleDto.EmployeesDto.ManagerDtos;

namespace CateringManagementPlatform.BLL.Interfaces
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
