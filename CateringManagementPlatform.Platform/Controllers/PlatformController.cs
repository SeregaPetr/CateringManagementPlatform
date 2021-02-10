using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;
using CateringManagementPlatform.BLL.Platform.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MyValidationException;

namespace CateringManagementPlatform.Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IDataForDepartmentService _dataForDepartmentService;

        public PlatformController(IDataForDepartmentService dataForDepartmentService)
        {
            _dataForDepartmentService = dataForDepartmentService;
        }

        // GET api/platform/order-lines-for-waiter
        [Route("order-lines-for-waiter")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLineReadDto>>> OrderLinesForWaiter()
        {
            var orderLinesForWaiter = await _dataForDepartmentService.GetOrderLinesForWaiter();
            return Ok(orderLinesForWaiter);
        }

        // GET api/platform/order-lines-for-kitchen
        [Route("order-lines-for-kitchen")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLineReadDto>>> OrderLinesForKitchen()
        {
            var orderLinesForKitchen = await _dataForDepartmentService.GetOrderLinesForKitchen();
            return Ok(orderLinesForKitchen);
        }

        // GET api/platform/order-lines-for-bar
        [Route("order-lines-for-bar")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLineReadDto>>> OrderLinesForBar()
        {
            var orderLinesForBar = await _dataForDepartmentService.GetOrderLinesForBar();
            return Ok(orderLinesForBar);
        }

        // GET api/platform/order-for-guest
        [Route("order-for-guest")]
        [HttpGet]
        public async Task<ActionResult<OrderReadDto>> OrdeForGuest()
        {
            int accountId = GetAccountId();

            var orderLinesForBar = await _dataForDepartmentService.GetOrderForGuest(accountId);
            return Ok(orderLinesForBar);
        }

        // POST api/platform/update-order-line
        [Route("update-order-line")]
        [HttpPost]
        public async Task<ActionResult<OrderLineReadDto>> UpdateOrderLine(OrderLineUpdateDto orderLineUpdateDto)
        {
            if (orderLineUpdateDto == null)
            {
                return BadRequest();
            }

            try
            {
                var orderLineReadDto = await _dataForDepartmentService.UpdateOrderLineAsync(orderLineUpdateDto);

                string url = Request.GetEncodedUrl();

                //  return CreatedAtAction(nameof(GetById), new { id = orderReadDto.Id }, orderReadDto);
                return Created(url, orderLineReadDto);
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

        // POST api/platform/create-order
        [Route("create-order")]
        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int accountId = GetAccountId();

                var orderReadDto = await _dataForDepartmentService.CreateOrderAsync(orderCreateDto, accountId);

                string url = Request.GetEncodedUrl();

                //  return CreatedAtAction(nameof(GetById), new { id = orderReadDto.Id }, orderReadDto);
                return Created(url, orderReadDto);
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

        private int GetAccountId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

        //PUT api/platforma/update-order/5
        [Route("update-order/{id}")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, OrderUpdateDto orderUpdateDto)
        {
            if (id != orderUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _dataForDepartmentService.UpdateOrderAsync(orderUpdateDto);

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
