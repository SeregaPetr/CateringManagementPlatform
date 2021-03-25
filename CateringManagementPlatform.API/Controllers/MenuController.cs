using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuDtos;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyValidationException;

namespace CateringManagementPlatform.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET: api/menu/active-menu
        [AllowAnonymous]
        [HttpGet("active-menu")]
        public async Task<ActionResult<MenuReadDto>> GetActiveMenu()
        {
            var menuReadDto = await _menuService.GetActiveMenuAsync();
            return Ok(menuReadDto);
        }

        // GET: api/menu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuReadDto>>> Get()
        {
            var menusReadDto = await _menuService.GetAllAsync();
            return Ok(menusReadDto);
        }

        // PUT api/menu/make-active-menu/5
        [HttpPut("make-active-menu/{id}")]
        public async Task<ActionResult> MakeActiveMenu(int id, MenuUpdateDto menuUpdateDto)
        {
            if (id != menuUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _menuService.MakeActiveMenuAsync(menuUpdateDto);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT api/menu/create-menu/5
        [HttpPut("create-menu/{id}")]
        public async Task<ActionResult> CreateMenu(int id, MenuUpdateDto menuUpdateDto)
        {
            if (id != menuUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _menuService.CreateMenuAsync(menuUpdateDto);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET api/menu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuReadDto>> GetById(int id)
        {
            try
            {
                var menuReadDto = await _menuService.GetByIdAsync(id);
                if (menuReadDto != null)
                {
                    return Ok(menuReadDto);
                }
                return NotFound();
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST api/menu
        [HttpPost]
        public async Task<ActionResult<MenuCreateDto>> Post(MenuCreateDto menuCreateDto)
        {
            if (menuCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int menuCreateId = await _menuService.CreateAsync(menuCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = menuCreateId }, menuCreateDto);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT api/menu/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MenuUpdateDto menuUpdateDto)
        {
            if (id != menuUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _menuService.UpdateAsync(menuUpdateDto);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE api/menu/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _menuService.DeleteAsync(id);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
