using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.DTO.PaymentTypeDtos;

namespace CateringManagementPlatform.BLL.Interfaces
{
    public interface IPaymentTypeService
    {
        Task<IEnumerable<PaymentTypeReadDto>> GetAllAsync();
        Task<PaymentTypeReadDto> GetByIdAsync(int id);
        void Dispose();
    }
}
