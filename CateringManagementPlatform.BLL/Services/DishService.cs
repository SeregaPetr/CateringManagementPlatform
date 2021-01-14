using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.DTO.DishDtos;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public DishService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(DishCreateDto dishCreateDto)
        {
            if (dishCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            var dish = _mapper.Map<Dish>(dishCreateDto);

            _repository.Dishes.Create(dish);
            await _repository.SaveAsync();

            return dish.Id;
        }

        public async Task<IEnumerable<DishReadDto>> GetAllAsync()
        {
            var dishes = await _repository.Dishes.GetAllAsync();
            return _mapper.Map<IEnumerable<DishReadDto>>(dishes);
        }

        public async Task<DishReadDto> GetByIdAsync(int id)
        {
            var dish = await _repository.Barmen.GetByIdAsync(id);
            if (dish == null)
            {
                throw new ValidationException("Блюдо не найден", "");
            }
            return _mapper.Map<DishReadDto>(dish);
        }

        public async Task UpdateAsync(DishUpdateDto dishUpdateDto)
        {
            var dish = await _repository.Dishes.GetByIdAsync(dishUpdateDto.Id);
            if (dish == null)
            {
                throw new ValidationException("Блюдо не найден", "");
            }
            dish.IsArchive = dishUpdateDto.IsArchive;

            _repository.Dishes.Update(dish);
            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
