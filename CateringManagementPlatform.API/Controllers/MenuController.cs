using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.MenuDtos;
using CateringManagementPlatform.BLL.Order.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CateringManagementPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET: api/menu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuDto>>> Get()
        {
            var menuDto = await _menuService.GetAllAsync();
            return Ok(menuDto);
        }
    }
}
