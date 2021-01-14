using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.DTO.TableDtos;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CateringManagementPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        // GET: api/table
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableReadDto>>> Get()
        {
            var tablesReadDto = await _tableService.GetAllAsync();
            return Ok(tablesReadDto);
        }

        // GET api/table/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableReadDto>> GetById(int id)
        {
            try
            {
                var tableReadDto = await _tableService.GetByIdAsync(id);
                if (tableReadDto != null)
                {
                    return Ok(tableReadDto);
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

        // POST api/table
        [HttpPost]
        public async Task<ActionResult<TableCreateDto>> Post(TableCreateDto tableCreateDto)
        {
            if (tableCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int tableCreateId = await _tableService.CreateAsync(tableCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = tableCreateId }, tableCreateDto);
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

        // PUT api/table/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TableUpdateDto tableUpdateDto)
        {
            if (id != tableUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _tableService.UpdateAsync(tableUpdateDto);
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

        // DELETE api/table/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _tableService.DeleteAsync(id);
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
