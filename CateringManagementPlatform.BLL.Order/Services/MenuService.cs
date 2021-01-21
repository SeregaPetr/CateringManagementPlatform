using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.Order.DTO.DishDtos;
using CateringManagementPlatform.BLL.Order.DTO.MenuCategoryDtos;
using CateringManagementPlatform.BLL.Order.DTO.MenuDtos;
using CateringManagementPlatform.BLL.Order.Interfaces;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.Order.Services
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public MenuService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuDto>> GetAllAsync()
        {
            var allMenu = await _repository.Menu.GetAllAsync();
            int idActiveMenu = allMenu.FirstOrDefault(m => m.IsActive == true).Id;

            var menuCategories = await _repository.MenuCategories.GetAllAsync();
            var activeMenuCategories = menuCategories.Where(c => c.MenuId == idActiveMenu);

            var dishes = await _repository.Dishes.GetAllAsync();

            var menuCategoriesDto = new List<MenuCategoryDto>();

            foreach (var activeMenuCategory in activeMenuCategories)
            {
                var dishesByMenuCategor = dishes.Where(d => d.MenuCategoryId == activeMenuCategory.Id);
                var dishDto = _mapper.Map<IEnumerable<DishDto>>(dishesByMenuCategor);

                menuCategoriesDto.Add(
                    new MenuCategoryDto()
                    {
                        NameCategory = activeMenuCategory.NameCategory,
                        Dishes = dishDto
                    });
            }

            return new List<MenuDto> { new MenuDto() { MenuCategories = menuCategoriesDto } };
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}

