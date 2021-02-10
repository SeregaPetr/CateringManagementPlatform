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

            menu.MenuCategories.ToList()
                .ForEach(mc => mc.Dishes = mc.Dishes.Where(d => d.IsArchive == false).ToList());

            return _mapper.Map<MenuReadDto>(menu);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}

