using System;
using System.Threading.Tasks;
using CateringManagementPlatform.API.HubConfig;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;
using CateringManagementPlatform.BLL.Order.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyValidationException;

namespace CateringManagementPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        //private readonly IOrderService _orderService;
        //private readonly IDataForDepartmentService _dataForDepartmentService;
        //private readonly IHubContext<PlatformHub> _hubContext;

        //public PlatformController(IOrderService orderService, IDataForDepartmentService dataForDepartmentService,
        //    IHubContext<PlatformHub> hubContext)
        //{
        //    _orderService = orderService;
        //    _dataForDepartmentService = dataForDepartmentService;
        //    _hubContext = hubContext;
        //}

        //// POST api/platform/create-order
        //[Route("create-order")]
        //public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto orderCreateDto)
        //{
        //    if (orderCreateDto == null)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        var orderReadDto = await _orderService.CreateAsync(orderCreateDto);

        //        var orderLines = await _dataForDepartmentService.GetNewOrderLineForBar();

        //        await _hubContext.Clients.All.SendAsync("sentFromClienToBar", orderLines);

        //        return CreatedAtAction(nameof(GetById), new { id = orderReadDto.Id }, orderReadDto);
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

        //// POST api/platforma/update-order
        ////[Route("update-order")]
        ////[HttpPost]
        ////public async Task UpdateOrder(OrderUpdateDto orderCreateDto)
        ////{

        ////}

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


