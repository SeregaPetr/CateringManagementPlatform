using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.DTO.PeopleDto.EmployeesDto.BarmanDtos;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CateringManagementPlatform.API.Controllers
{
    [Authorize(Roles = "Barman")]
    [Route("api/[controller]")]
    [ApiController]
    public class BarmanController : ControllerBase
    {
        private readonly IBarmanService _barmanService;

        public BarmanController(IBarmanService barmanService)
        {
            _barmanService = barmanService;
        }

        // GET: api/barman
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarmanReadDto>>> Get()
        {
            var barmenReadDto = await _barmanService.GetAllAsync();
            return Ok(barmenReadDto);
        }

        // GET api/barman/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BarmanReadDto>> GetById(int id)
        {
            try
            {
                var barmanReadDto = await _barmanService.GetByIdAsync(id);
                if (barmanReadDto != null)
                {
                    return Ok(barmanReadDto);
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
        public async Task<ActionResult<BarmanCreateDto>> Post(BarmanCreateDto barmanCreateDto)
        {
            if (barmanCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int barmanCreateId = await _barmanService.CreateAsync(barmanCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = barmanCreateId }, barmanCreateDto);
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
        public async Task<ActionResult> Update(int id, BarmanUpdateDto barmanUpdateDto)
        {
            if (id != barmanUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _barmanService.UpdateAsync(barmanUpdateDto);
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
                await _barmanService.DeleteAsync(id);
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
