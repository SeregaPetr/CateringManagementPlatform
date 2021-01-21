using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.EmployeesDto.ChefDtos;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyValidationException;

namespace CateringManagementPlatform.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly IChefService _chefService;

        public ChefController(IChefService chefService)
        {
            _chefService = chefService;
        }

        // GET: api/barman
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChefReadDto>>> Get()
        {
            var chefsReadDto = await _chefService.GetAllAsync();
            return Ok(chefsReadDto);
        }

        // GET api/barman/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChefReadDto>> GetById(int id)
        {
            try
            {
                var chefReadDto = await _chefService.GetByIdAsync(id);
                if (chefReadDto != null)
                {
                    return Ok(chefReadDto);
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

        // POST api/barman
        [HttpPost]
        public async Task<ActionResult<ChefCreateDto>> Post(ChefCreateDto chefCreateDto)
        {
            if (chefCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int chefCreateId = await _chefService.CreateAsync(chefCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = chefCreateId }, chefCreateDto);
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

        // PUT api/barman/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ChefUpdateDto chefUpdateDto)
        {
            if (id != chefUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _chefService.UpdateAsync(chefUpdateDto);
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

        // DELETE api/barman/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _chefService.DeleteAsync(id);
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
