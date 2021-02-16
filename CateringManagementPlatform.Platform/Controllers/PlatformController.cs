using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;
using CateringManagementPlatform.BLL.Platform.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
            var orderLinesForWaiter = await _dataForDepartmentService.GetOrderLinesForWaiterAsync();
            return Ok(orderLinesForWaiter);
        }

        // GET api/platform/order-lines-for-kitchen
        [Route("order-lines-for-kitchen")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLineReadDto>>> OrderLinesForKitchen()
        {
            var orderLinesForKitchen = await _dataForDepartmentService.GetOrderLinesForKitchenAsync();
            return Ok(orderLinesForKitchen);
        }

        // GET api/platform/order-lines-for-bar
        [Route("order-lines-for-bar")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLineReadDto>>> OrderLinesForBar()
        {
            var orderLinesForBar = await _dataForDepartmentService.GetOrderLinesForBarAsync();
            return Ok(orderLinesForBar);
        }

        [Route("unpaid-orders")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> UnpaidOrders()
        {
            var unpaidOrders = await _dataForDepartmentService.GetUnpaidOrdersAsync();
            return Ok(unpaidOrders);
        }

        // GET api/platform/order-for-guest
        [Authorize]
        [Route("order-for-guest")]
        [HttpGet]
        public async Task<ActionResult<OrderReadDto>> OrdeForGuest()
        {
            int accountId = GetAccountId();

            var orderLinesForBar = await _dataForDepartmentService.GetOrderForGuestAsync(accountId);
            return Ok(orderLinesForBar);
        }

        // PUT api/platform/update-order-line/5
        [Route("update-order-line/{id}")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderLine(int id, OrderLineUpdateDto orderLineUpdateDto)
        {
            if (id != orderLineUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                await _dataForDepartmentService.UpdateOrderLineAsync(orderLineUpdateDto);

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

        // PUT api/platform/confirm-payment/5
        [Route("confirm-payment/{id}")]
        [HttpPut("{id}")]
        public async Task<ActionResult> ConfirmPayment(int id)
        {
            try
            {
                await _dataForDepartmentService.ConfirmPaymentAsync(id);

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

        // POST api/platform/confirm-order
        [Route("confirm-order")]
        [HttpPost]
        public async Task<ActionResult> ConfirmOrder(OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                int accountId = GetAccountId();

                await _dataForDepartmentService.ConfirOrderAsync(orderCreateDto, accountId);

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

        // POST api/platform/payment/5
        [Route("payment/{id}")]
        [HttpPost("{id}")]
        public async Task<ActionResult> Payment(int id,OrderUpdateDto orderUpdateDto)
        {
            if (id != orderUpdateDto?.Id)
            {
                return BadRequest();
            }

            try
            {
                int accountId = GetAccountId();

                await _dataForDepartmentService.PaymentAsync(orderUpdateDto, accountId);

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

        private int GetAccountId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

    }
}
