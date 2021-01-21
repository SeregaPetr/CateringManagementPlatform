using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PaymentTypeDtos;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyValidationException;

namespace CateringManagementPlatform.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        // GET: api/paymentType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTypeReadDto>>> Get()
        {
            var paymentTypesReadDto = await _paymentTypeService.GetAllAsync();
            return Ok(paymentTypesReadDto);
        }

        // GET api/paymentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTypeReadDto>> GetById(int id)
        {
            try
            {
                var paymentTypeReadDto = await _paymentTypeService.GetByIdAsync(id);
                if (paymentTypeReadDto != null)
                {
                    return Ok(paymentTypeReadDto);
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
    }
}
