using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.DTO.PeopleDto.EmployeesDto.ManagerDtos;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CateringManagementPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        // GET: api/manager
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerReadDto>>> Get()
        {
            var managerReadDto = await _managerService.GetAllAsync();
            return Ok(managerReadDto);
        }

        // GET api/manager/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerReadDto>> GetById(int id)
        {
            try
            {
                var managerReadDto = await _managerService.GetByIdAsync(id);
                if (managerReadDto != null)
                {
                    return Ok(managerReadDto);
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

        // POST api/manager
        [HttpPost]
        public async Task<ActionResult<ManagerCreateDto>> Post(ManagerCreateDto managerCreateDto)
        {
            if (managerCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int managerCreateId = await _managerService.CreateAsync(managerCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = managerCreateId }, managerCreateDto);
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

        // PUT api/manager/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ManagerUpdateDto managerUpdateDto)
        {
            if (id != managerUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _managerService.UpdateAsync(managerUpdateDto);
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

        // DELETE api/manager/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _managerService.DeleteAsync(id);
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
