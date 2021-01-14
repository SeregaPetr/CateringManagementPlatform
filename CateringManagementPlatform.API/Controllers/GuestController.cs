using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.DTO.PeopleDto.GuestDtos;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CateringManagementPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        // GET: api/guest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestReadDto>>> Get()
        {
            var guestsReadDto = await _guestService.GetAllAsync();
            return Ok(guestsReadDto);
        }

        // GET api/guest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestReadDto>> GetById(int id)
        {
            try
            {
                var guestReadDto = await _guestService.GetByIdAsync(id);
                if (guestReadDto != null)
                {
                    return Ok(guestReadDto);
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

        // POST api/guest
        [HttpPost]
        public async Task<ActionResult<GuestCreateDto>> Post(GuestCreateDto guestCreateDto)
        {
            if (guestCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int guestCreateId = await _guestService.CreateAsync(guestCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = guestCreateId }, guestCreateDto);
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

        // PUT api/guest/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, GuestUpdateDto guestUpdateDto)
        {
            if (id != guestUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _guestService.UpdateAsync(guestUpdateDto);
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

        // DELETE api/guest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _guestService.DeleteAsync(id);
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
