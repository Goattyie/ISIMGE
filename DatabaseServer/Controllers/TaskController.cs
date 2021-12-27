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

        [Route("/api/task/")]
        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _serviceTaskRepository.GetAll().ToList();
            return Ok(tasks);
        }

        [Route("/api/task/id={id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var task = _serviceTaskRepository.Get(id);
            return Ok(task);
        }

        [Route("/api/task/name={name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var task = _serviceTaskRepository.Get(name);
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
