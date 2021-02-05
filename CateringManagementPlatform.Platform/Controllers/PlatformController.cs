using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;
using CateringManagementPlatform.BLL.Order.Interfaces;
using CateringManagementPlatform.BLL.Platform.HubConfig;
using CateringManagementPlatform.BLL.Platform.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyValidationException;

namespace CateringManagementPlatform.Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IDataForDepartmentService _dataForDepartmentService;
        private readonly IHubContext<PlatformHub> _hubContext;

        public PlatformController( IDataForDepartmentService dataForDepartmentService,            IHubContext<PlatformHub> hubContext)
        {
             _dataForDepartmentService= dataForDepartmentService;
            _hubContext = hubContext;
        }

        // GET api/platform/create-order
        [Route("order-lines-for-bar")]
        public async Task<ActionResult<IEnumerable<OrderLineReadDto>>> OrderLinesForBar()
        {
            var orderLinesForBar = await _dataForDepartmentService.GetOrderLinesForBar();
            return Ok(orderLinesForBar);
        }

        // POST api/platform/create-order
        [Route("create-order")]
        public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto == null)
            {
                return BadRequest();
            }

            try
            {
                var orderReadDto =await  _dataForDepartmentService.CreateOrderAsync(orderCreateDto);

                var orderLinesForBar = await _dataForDepartmentService.GetOrderLinesForBar();

                await _hubContext.Clients.All.SendAsync("sentFromClienToBar", orderLinesForBar);
                
                // GetDisplayUrl
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

        // POST api/platforma/update-order
        //[Route("update-order")]
        //[HttpPost]
        //public async Task UpdateOrder(OrderUpdateDto orderCreateDto)
        //{

        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<OrderReadDto>> GetById(int id)
        //{
        //    try
        //    {
        //        var orderReadDto = await _orderService.GetByIdAsync(id);
        //        if (orderReadDto != null)
        //        {
        //            return Ok(orderReadDto);
        //        }
        //        return NotFound();
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return Content(ex.Message);
        //    }
        //    catch (Exception)
        //    {
        //        return NotFound();
        //    }
        //}
    }
}
