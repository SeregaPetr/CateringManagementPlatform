using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.GuestDtos;
using CateringManagementPlatform.BLL.AdminPanel.Infrastructure;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.AdminPanel.Services
{
    public class GuestService : IGuestService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GuestService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(GuestCreateDto guestCreateDto)
        {
            if (guestCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            var guest = _mapper.Map<Guest>(guestCreateDto);

            _repository.Guests.Create(guest);
            await _repository.SaveAsync();

            return guest.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var guest = await _repository.Guests.GetByIdAsync(id);
            if (guest == null)
            {
                throw new ValidationException("Гость не найден", "");
            }
            _repository.Guests.Delete(guest);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<GuestReadDto>> GetAllAsync()
        {
            var guests = await _repository.Guests.GetAllAsync();
            return _mapper.Map<IEnumerable<GuestReadDto>>(guests);
        }

        public async Task<GuestReadDto> GetByIdAsync(int id)
        {
            var guest = await _repository.Guests.GetByIdAsync(id);
            if (guest == null)
            {
                throw new ValidationException("Гость не найден", "");
            }
            return _mapper.Map<GuestReadDto>(guest);
        }

        public async Task UpdateAsync(GuestUpdateDto guestUpdateDto)
        {
            var guest = await _repository.Guests.GetByIdAsync(guestUpdateDto.Id);
            if (guest == null)
            {
                throw new ValidationException("Гость не найден", "");
            }
            guest = _mapper.Map<Guest>(guestUpdateDto);

            _repository.Guests.Update(guest);
            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
