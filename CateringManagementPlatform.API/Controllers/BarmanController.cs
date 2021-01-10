using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.DTO.People.Employees;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CateringManagementPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarmanController : ControllerBase
    {
        private readonly IService<BarmanDto> _barmanService;

        public BarmanController(IService<BarmanDto> barmanService)
        {
            _barmanService = barmanService;
        }

        // GET: api/barman
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarmanDto>>> Get()
        {
            var barmanDto = await _barmanService.GetAllAsync();
            return Ok(barmanDto);
        }

        // GET api/barman/5
        [HttpGet("{id}")]// добавить name
        public async Task<ActionResult<BarmanDto>> GetById(int id)
        {
            try
            {
                var barmanDto = await _barmanService.GetByIdAsync(id);
                if (barmanDto != null)
                {
                    return Ok(barmanDto);
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
        public async Task<ActionResult<BarmanDto>> Post(BarmanDto barmanDto)
        {
            if (barmanDto == null)
            {
                return BadRequest();
            }

            try
            {
                await _barmanService.CreateAsync(barmanDto);
                return CreatedAtAction(nameof(GetById), new { id = barmanDto.Id }, barmanDto);
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
        public async Task<ActionResult> UpdateCommand(int id, BarmanDto barmanDto)
        {
            if (id != barmanDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _barmanService.UpdateAsync(barmanDto);
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
        public async Task<ActionResult> DeleteCommand(int id)
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
