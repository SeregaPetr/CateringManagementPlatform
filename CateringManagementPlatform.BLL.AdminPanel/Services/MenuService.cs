using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DishDtos;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuDtos;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.AdminPanel.Services
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

        public async Task<MenuReadDto> GetAsync()
        {
            var allMenu = await _repository.Menu.GetAllAsync();

            var menu = allMenu.FirstOrDefault(m => m.IsActive == false);

            List<MenuCategoryReadDto> menuCategoryReadDtos = new List<MenuCategoryReadDto>();

            for (int i = 0; i < menu.MenuCategories.Count; i++)
            {
                MenuCategoryReadDto menuCategoryCreateDto = new MenuCategoryReadDto
                {
                    NameCategory = menu.MenuCategories.ToArray()[i].NameCategory,
                    Dishes = _mapper.Map<List<DishReadDto>>(menu.MenuCategoryMenus.ToArray()[i].Dishes)
                };
                menuCategoryReadDtos.Add(menuCategoryCreateDto);
            }

            MenuReadDto menuReadDto = new MenuReadDto
            {
                NameMenu = menu.NameMenu,
                MenuCategories = menuCategoryReadDtos
            };

            return menuReadDto;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
