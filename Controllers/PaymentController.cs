using AutoMapper;
using backend.Models.Payment;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _paymentService.GetAll();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _paymentService.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult Create([FromBody] CreateRequestPayment modelDto)
        {
            try
            {
                _paymentService.Create(modelDto);
                return Ok(new { message = "Payment created" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while creating the payment" });
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                _paymentService.Delete(id);
                return Ok(new { message = "Payment deleted" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the payment" });
            }
        }
    }
}
