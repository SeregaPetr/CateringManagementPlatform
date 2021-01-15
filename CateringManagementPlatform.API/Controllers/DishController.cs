using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DishDtos;
using CateringManagementPlatform.BLL.AdminPanel.Infrastructure;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CateringManagementPlatform.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        // GET: api/dish
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishReadDto>>> Get()
        {
            var dishReadDto = await _dishService.GetAllAsync();
            return Ok(dishReadDto);
        }

        // GET api/dish/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DishReadDto>> GetById(int id)
        {
            try
            {
                var dishReadDto = await _dishService.GetByIdAsync(id);
                if (dishReadDto != null)
                {
                    return Ok(dishReadDto);
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

        // POST api/dish
        [HttpPost]
        public async Task<ActionResult<DishCreateDto>> Post(DishCreateDto dishCreateDto)
        {
            if (dishCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int dishCreateId = await _dishService.CreateAsync(dishCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = dishCreateId }, dishCreateDto);
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

        // PUT api/dish/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DishUpdateDto dishUpdateDto)
        {
            if (id != dishUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _dishService.UpdateAsync(dishUpdateDto);
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
