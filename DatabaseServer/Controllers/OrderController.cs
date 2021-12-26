using Common.Models;
using DatabaseServer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderRepository.GetAll();
            return Ok(orders);
        }

        [Route ("add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Order order)
        {
            try
            {
                await _orderRepository.Add(order);
                await _orderRepository.SaveAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
