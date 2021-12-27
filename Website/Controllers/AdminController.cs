using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using Website.Middleware;

namespace Website.Controllers
{
    [Route ("admin")]
    public class AdminController : Controller
    {
        private HttpClient _httpClient;
        public IActionResult Index() => View();
        [Route ("tasks")]
        public IActionResult Tasks() => View();
        [Route("services")]
        public IActionResult Services() => View();
        [Route("city")]
        public IActionResult City() => View();

        [Route("services")]
        [HttpPost]
        public async Task<IActionResult> Services(Service service)
        {
            _httpClient = new();
            var json = JsonConvert.SerializeObject(service);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:7270/api/service/add", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectPermanent("/admin/services");
            }
            return BadRequest();
        }
        [Route("tasks")]
        [HttpPost]
        public async Task<IActionResult> Tasks(ServiceTask task)
        {
            var middleware = new CheackDataTaskMiddleware(new CheckTaskInDatabaseMiddleware());
            try
            {
                await middleware.Execute(task);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            _httpClient = new();
            var json = JsonConvert.SerializeObject(task);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:7270/api/task/add", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectPermanent("/admin/tasks");
            }
            return BadRequest();
        }
    }
}
