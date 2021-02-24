using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.Interfaces
{
    public interface IMenuService
    {
        Task<MenuReadDto> GetAsync();
        void Dispose();
    }
}
