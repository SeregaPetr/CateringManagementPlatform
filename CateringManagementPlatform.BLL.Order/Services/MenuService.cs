using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public async Task<MenuReadDto> GetAsync()
        {
            var allMenu = await _repository.Menu.GetAllAsync();
            var menu = allMenu.FirstOrDefault(m => m.IsActive == false);

            return _mapper.Map<MenuReadDto>(menu);
        }

        //TODO исправить!!! выдавать все меню и перенести в BLL.AdminPanel
        //public async Task<IEnumerable<MenuReadDto>> GetAllAsync()
        //{
        //    var allMenu = await _repository.Menu.GetAllAsync();
        //    int idActiveMenu = allMenu.FirstOrDefault(m => m.IsActive == true).Id;

        //    var menuCategories = await _repository.MenuCategories.GetAllAsync();
        //    var activeMenuCategories = menuCategories.Where(c => c.MenuId == idActiveMenu);

        //    var dishes = await _repository.Dishes.GetAllAsync();

        //    var menuCategoriesDto = new List<MenuCategoryReadDto>();

        //    foreach (var activeMenuCategory in activeMenuCategories)
        //    {
        //        var dishesByMenuCategor = dishes.Where(d => d.MenuCategoryId == activeMenuCategory.Id);
        //        var dishDto = _mapper.Map<IEnumerable<DishReadDto>>(dishesByMenuCategor);

        //        menuCategoriesDto.Add(
        //            new MenuCategoryReadDto()
        //            {
        //                NameCategory = activeMenuCategory.NameCategory,
        //                Dishes = dishDto
        //            });
        //    }

        //    return new List<MenuReadDto> { new MenuReadDto() { MenuCategories = menuCategoriesDto } };
        //}

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}

