using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DepartmentDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentReadDto>> GetAllAsync();
        void Dispose();
    }
}
