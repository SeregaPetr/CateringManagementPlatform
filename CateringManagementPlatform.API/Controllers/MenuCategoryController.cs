using System;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyValidationException;

namespace CateringManagementPlatform.API.Controllers
{
    [Authorize(Roles = "Admin")]
[Route("api/[controller]")]
    [ApiController]
    public class MenuCategoryController : ControllerBase
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public MenuCategoryController(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }

        // GET: api/menuCategory
        [HttpGet]
        public async Task<ActionResult<MenuCategoryReadDto>> GetMenu()
        {
            var menuReadDto = await _menuCategoryService.GetAllAsync();
            return Ok(menuReadDto);
        }

        // GET api/menuCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuCategoryReadDto>> GetById(int id)
        {
            try
            {
                var menuCategoryReadDto = await _menuCategoryService.GetByIdAsync(id);
                if (menuCategoryReadDto != null)
                {
                    return Ok(menuCategoryReadDto);
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

        // POST api/menuCategory
        [HttpPost]
        public async Task<ActionResult<MenuCategoryCreateDto>> Post(MenuCategoryCreateDto menuCategoryCreateDto)
        {
            if (menuCategoryCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int menuCategoryCreateId = await _menuCategoryService.CreateAsync(menuCategoryCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = menuCategoryCreateId }, menuCategoryCreateDto);
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

        // PUT api/menuCategory/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MenuCategoryUpdateDto menuCategoryUpdateDto)
        {
            if (id != menuCategoryUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _menuCategoryService.UpdateAsync(menuCategoryUpdateDto);
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

        // DELETE api/menuCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _menuCategoryService.DeleteAsync(id);
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
