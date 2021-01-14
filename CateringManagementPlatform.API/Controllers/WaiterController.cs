using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.DTO.PeopleDto.EmployeesDto.WaiterDtos;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CateringManagementPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaiterController : ControllerBase
    {
        private readonly IWaiterService _waiterService;

        public WaiterController(IWaiterService waiterService)
        {
            _waiterService = waiterService;
        }

        // GET: api/waiter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaiterReadDto>>> Get()
        {
            var waitersReadDto = await _waiterService.GetAllAsync();
            return Ok(waitersReadDto);
        }

        // GET api/waiter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaiterReadDto>> GetById(int id)
        {
            try
            {
                var waiterReadDto = await _waiterService.GetByIdAsync(id);
                if (waiterReadDto != null)
                {
                    return Ok(waiterReadDto);
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

        // POST api/waiter
        [HttpPost]
        public async Task<ActionResult<WaiterUpdateDto>> Post(WaiterCreateDto waiterCreateDto)
        {
            if (waiterCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int waiterCreateId = await _waiterService.CreateAsync(waiterCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = waiterCreateId }, waiterCreateDto);
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

        // PUT api/waiter/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, WaiterUpdateDto waiterUpdateDto)
        {
            if (id != waiterUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _waiterService.UpdateAsync(waiterUpdateDto);
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

        // DELETE api/waiter/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _waiterService.DeleteAsync(id);
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
