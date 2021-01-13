using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.DTO.TableDtos;

namespace CateringManagementPlatform.BLL.Interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<TableReadDto>> GetAllAsync();
        Task<TableReadDto> GetByIdAsync(int id);
        Task<int> CreateAsync(TableCreateDto tableCreateDto);
        Task UpdateAsync(TableUpdateDto tableUpdateDto);
        Task DeleteAsync(int id);
        void Dispose();
    }
}
