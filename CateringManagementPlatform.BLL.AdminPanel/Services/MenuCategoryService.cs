using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using MyValidationException;

namespace CateringManagementPlatform.BLL.AdminPanel.Services
{
    public class MenuCategoryService : IMenuCategoryService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public MenuCategoryService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuCategoryReadDto>> GetAllAsync()
        {
            var menuCategories = await _repository.MenuCategories.GetAllAsync();

            return _mapper.Map<IEnumerable<MenuCategoryReadDto>>(menuCategories);
        }

        public async Task<MenuCategoryReadDto> GetByIdAsync(int id)
        {
            var menuCategory = await _repository.MenuCategories.GetByIdAsync(id);
            if (menuCategory == null)
            {
                throw new ValidationException("Категория меню не найдена", "");
            }
            return _mapper.Map<MenuCategoryReadDto>(menuCategory);
        }

        public async Task<int> CreateAsync(MenuCategoryCreateDto menuCategoryCreateDto)
        {
            if (menuCategoryCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }

            await TestForMenuCategoryExistence(menuCategoryCreateDto.NameCategory);

            var menuCategory = _mapper.Map<MenuCategory>(menuCategoryCreateDto);

            _repository.MenuCategories.Create(menuCategory);
            await _repository.SaveAsync();

            return menuCategory.Id;
        }

        public async Task UpdateAsync(MenuCategoryUpdateDto menuCategoryUpdateDto)
        {
            var menuCategory = await _repository.MenuCategories.GetByIdAsync(menuCategoryUpdateDto.Id);
            if (menuCategory == null)
            {
                throw new ValidationException("Категория меню не найдена", "");
            }

            if (!menuCategory.NameCategory.Equals(menuCategoryUpdateDto.NameCategory))
            {
                await TestForMenuCategoryExistence(menuCategoryUpdateDto.NameCategory);
            }
            var menuCategoryUpdate = _mapper.Map<MenuCategory>(menuCategoryUpdateDto);

            _repository.MenuCategories.Update(menuCategoryUpdate);
            await _repository.SaveAsync();
        }

        private async Task TestForMenuCategoryExistence(string NameCategory)
        {
            var menuCategories = await _repository.MenuCategories.GetAllAsync();
            var menuCategoryExists = menuCategories.Any(t => t.NameCategory.Equals(NameCategory));

            if (menuCategoryExists)
            {
                throw new ValidationException("Категория меню уже существует", "");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var menuCategory = await _repository.MenuCategories.GetByIdAsync(id);
            if (menuCategory == null)
            {
                throw new ValidationException("Категория меню не найдена", "");
            }
            _repository.MenuCategories.Delete(menuCategory);
            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
