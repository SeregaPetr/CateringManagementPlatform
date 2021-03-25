using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DishDtos;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuDtos;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using MyValidationException;

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

        public async Task<MenuReadDto> GetActiveMenuAsync()
        {
            var allMenu = await _repository.Menu.GetAllAsync();

            var menu = allMenu.FirstOrDefault(m => m.IsActive == true);

            MenuReadDto menuReadDto = MapMenuToMenuReadDto(menu);

            return menuReadDto;
        }

        private MenuReadDto MapMenuToMenuReadDto(Menu menu)
        {
            List<MenuCategoryReadDto> menuCategoryReadDtos = new List<MenuCategoryReadDto>();

            for (int i = 0; i < menu.MenuCategories.Count; i++)
            {
                MenuCategoryReadDto menuCategoryCreateDto = new MenuCategoryReadDto
                {
                    Id = menu.MenuCategoryMenus.ToArray()[i].MenuCategoryId,
                    NameCategory = menu.MenuCategories.ToArray()[i].NameCategory,
                    Dishes = _mapper.Map<IEnumerable<DishReadDto>>(menu.MenuCategoryMenus.ToArray()[i].Dishes)
                };
                menuCategoryReadDtos.Add(menuCategoryCreateDto);
            }

            MenuReadDto menuReadDto = new MenuReadDto
            {
                Id = menu.Id,
                NameMenu = menu.NameMenu,
                MenuCategories = menuCategoryReadDtos,
                IsActive = menu.IsActive
            };
            return menuReadDto;
        }

        public async Task<IEnumerable<MenuReadDto>> GetAllAsync()
        {
            var menus = await _repository.Menu.GetAllAsync();

            return _mapper.Map<IEnumerable<MenuReadDto>>(menus);
        }

        public async Task MakeActiveMenuAsync(MenuUpdateDto menuUpdateDto)
        {
            var menus = await _repository.Menu.GetAllAsync();
            var activeMenu = menus.Single(m => m.IsActive == true);

            activeMenu.IsActive = false;
            activeMenu.MenuCategories = null;
            activeMenu.MenuCategoryMenus = null;

            _repository.Menu.Update(activeMenu);

            menuUpdateDto.IsActive = true;
            var newActiveMenu = _mapper.Map<Menu>(menuUpdateDto);

            _repository.Menu.Update(newActiveMenu);
            await _repository.SaveAsync();
        }

        public async Task<MenuReadDto> GetByIdAsync(int id)
        {
            var menu = await _repository.Menu.GetByIdAsync(id);
            if (menu == null)
            {
                throw new ValidationException("Категория меню не найдена", "");
            }
            MenuReadDto menuReadDto = MapMenuToMenuReadDto(menu);

            return menuReadDto;
        }

        public async Task<int> CreateAsync(MenuCreateDto menuCreateDto)
        {
            if (menuCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }

            await TestForMenuExistence(menuCreateDto.NameMenu);
            var menu = _mapper.Map<Menu>(menuCreateDto);

            _repository.Menu.Create(menu);
            await _repository.SaveAsync();

            return menu.Id;
        }

        private async Task TestForMenuExistence(string NameMenu)
        {
            var menus = await _repository.Menu.GetAllAsync();
            var menuCategoryExists = menus.Any(t => t.NameMenu.Equals(NameMenu));

            if (menuCategoryExists)
            {
                throw new ValidationException("Название меню уже существует", "");
            }
        }

        public async Task UpdateAsync(MenuUpdateDto menuUpdateDto)
        {
            var menu = await _repository.Menu.GetByIdAsync(menuUpdateDto.Id);
            if (menu == null)
            {
                throw new ValidationException("Меню не найдено", "");
            }

            if (!menu.NameMenu.Equals(menuUpdateDto.NameMenu))
            {
                await TestForMenuExistence(menuUpdateDto.NameMenu);
            }

            menu.NameMenu = menuUpdateDto.NameMenu;
            menu.IsActive = menuUpdateDto.IsActive;
            await _repository.SaveAsync();
        }

        public async Task CreateMenuAsync(MenuUpdateDto menuUpdateDto)
        {
            var menu = await _repository.Menu.GetByIdAsync(menuUpdateDto.Id);
            if (menu == null)
            {
                throw new ValidationException("Меню не найдено", "");
            }

            menu.MenuCategoryMenus = new List<MenuCategoryMenu>();

            foreach (var menuCategory in menuUpdateDto.MenuCategories)
            {
                var menuCategoryMenu = new MenuCategoryMenu
                {
                    MenuId = menu.Id,
                    MenuCategoryId = menuCategory.Id,
                };

                menu.MenuCategoryMenus.Add(menuCategoryMenu);
                await _repository.SaveAsync();

                foreach (var dish in menuCategory.Dishes)
                {
                    var dishDB = await _repository.Dishes.GetByIdAsync(dish.Id);
                    dishDB.MenuCategoryMenus.Add(menuCategoryMenu);
                }
            }
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menu = await _repository.Menu.GetByIdAsync(id);
            if (menu == null)
            {
                throw new ValidationException("Меню не найдено", "");
            }
            _repository.Menu.Delete(menu);
            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
