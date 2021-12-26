using Common.Models;
using DatabaseServer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ServiceTaskRepository _serviceTaskRepository;

        public TaskController(ServiceTaskRepository serviceTaskRepository)
        {
            _serviceTaskRepository = serviceTaskRepository;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                var tasks = _serviceTaskRepository.GetAll().ToList();
                return Ok(tasks);
            }
            var task = _serviceTaskRepository.Get(id);
            return Ok(task);
        }

        [Route ("add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ServiceTask task)
        {
            try
            {
                await _serviceTaskRepository.Add(task);
                await _serviceTaskRepository.SaveAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
