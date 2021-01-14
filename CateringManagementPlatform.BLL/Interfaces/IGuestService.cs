using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.DTO.PeopleDto.GuestDtos;

namespace CateringManagementPlatform.BLL.Interfaces
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
