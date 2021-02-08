using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.Auth.DTO;
using CateringManagementPlatform.BLL.Auth.Interfaces;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<IEnumerable<AccountReadDto>> GetAllAsync()
        {
            var accounts = await _repository.Accounts.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountReadDto>>(accounts);
        }

    }
}
