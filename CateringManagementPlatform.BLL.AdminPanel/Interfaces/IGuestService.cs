using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.GuestDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.Interfaces
{
    public interface IGuestService
    {
        Task<IEnumerable<GuestReadDto>> GetAllAsync();
        Task<GuestReadDto> GetByIdAsync(int id);
        Task<int> CreateAsync(GuestCreateDto guestCreateDto);
        Task UpdateAsync(GuestUpdateDto guestUpdateDto);
        Task DeleteAsync(int id);
        void Dispose();
    }
}
