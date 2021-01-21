using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyValidationException;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CateringManagementPlatform.API.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //// GET: api/order
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<OrderReadDto>>> Get()
        //{
        //    var ordersReadDto = await _orderService.GetAllAsync();
        //    return Ok(ordersReadDto);
        //}

        // GET api/order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDto>> GetById(int id)
        {
            try
            {
                var orderReadDto = await _orderService.GetByIdAsync(id);
                if (orderReadDto != null)
                {
                    return Ok(orderReadDto);
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

        // POST api/order
        [HttpPost]
        public async Task<ActionResult<OrderCreateDto>> Post(OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int orderCreateId = await _orderService.CreateAsync(orderCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = orderCreateId }, orderCreateDto);
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

       // PUT api/order/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, OrderUpdateDto orderUpdateDto)
        {
            if (id != orderUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _orderService.UpdateAsync(orderUpdateDto);
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

        //// DELETE api/order/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
    }
}

