using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PaymentTypeDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.Interfaces
{
    public interface IPaymentTypeService
    {
        Task<IEnumerable<PaymentTypeReadDto>> GetAllAsync();
        Task<PaymentTypeReadDto> GetByIdAsync(int id);
        void Dispose();
    }
}
