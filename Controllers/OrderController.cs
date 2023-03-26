using AutoMapper;
using backend.Models.Order;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;

        public OrdersController(
            IOrderService orderService,
            ICommonService commonService,
            IMapper mapper)
        {
            _orderService = orderService;
            _commonService = commonService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _orderService.GetById(id);
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create(CreateRequestOrder model)
        {
            if (!HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                // Authorization header is not present
                return Unauthorized();
            }
            else
            {
                // Authorization header is present, split the value to remove the "Bearer " prefix
                // e.g. "Bearer token-value" -> "token-value"
                var tokenValue = authHeader.ToString().Split(" ")[1];

                if (_commonService.IsValid(tokenValue))
                {
                    _orderService.Create(model);
                    return Ok(new { message = "Order created" });
                }
                else
                {
                    return BadRequest(new { message = "Session expired!" });
                }
            }
        }


    }
}
