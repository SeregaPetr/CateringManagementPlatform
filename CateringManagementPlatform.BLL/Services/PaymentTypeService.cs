using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.DTO.PaymentTypeDtos;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.Services
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public PaymentTypeService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentTypeReadDto>> GetAllAsync()
        {
            var paymentTypes = await _repository.PaymentTypes.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentTypeReadDto>>(paymentTypes);
        }

        public async Task<PaymentTypeReadDto> GetByIdAsync(int id)
        {
            var paymentType = await _repository.Barmen.GetByIdAsync(id);
            if (paymentType == null)
            {
                throw new ValidationException("Платежная система не найдена", "");
            }
            return _mapper.Map<PaymentTypeReadDto>(paymentType);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
