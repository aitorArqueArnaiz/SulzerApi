using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sulzer.Domain.Interfaces;
using Sulzer.Domain.Models;
using SulzerApi.DTOs.Request;

namespace SulzerApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerOrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<CustomerOrdersController> _logger;
        private IMapper _mapper;

        public CustomerOrdersController(ILogger<CustomerOrdersController> logger, IOrderService orderService, IMapper mapper)
        {
            _logger = logger;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> CalculateOrderTotalPriceAsync(CustomerOrderRequest request)
        {
            try
            {
                var customerOrderRequest = _mapper.Map<CustomerOrder>(request);
                var response = await _orderService.CalculateOrderTotalPriceAsync(customerOrderRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error procesing the orders total price request {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
