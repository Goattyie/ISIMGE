using Common.Models;
using DatabaseServer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceRepository _serviceRepository;

        public ServiceController(ServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var services = _serviceRepository.GetAll();
            return Ok(services);
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Service service)
        {
            try
            {
                await _serviceRepository.Add(service);
                await _serviceRepository.SaveAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
