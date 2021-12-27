using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Website.Utils;

namespace Website.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private HttpClient _httpClient = new();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route ("services")]
        [HttpGet]
        public async Task<IActionResult> Services()
        {
            var response = await _httpClient.GetAsync("http://localhost:7270/api/service");
            var response2 = await _httpClient.GetAsync("http://localhost:7270/api/task/");
            if(response.IsSuccessStatusCode && response2.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var data2 = await response2.Content.ReadAsStringAsync();
                var services = data.AsServiceList().ToList();
                var tasks = data2.AsServiceTaskList().ToList();
                for (int i = 0; i < services.Count; i++)
                {
                    services[i].Tasks = tasks;
                }
                return View(services);
            }
            return BadRequest();
        }

        [Route("orders")]
        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            if (Request.Cookies["user_id"] == null) return Ok("Авторизируйтесь.");
            var response = await _httpClient.GetAsync($"http://localhost:7270/api/order?user_id={Request.Cookies["user_id"]}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var orders = data.AsOrderList();
                return View(orders);
            }
            return BadRequest();
        }

        [Route("/order/add")]
        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            if (Request.Cookies["user_id"] == null) return Ok("Авторизируйтесь.");
            var response = await _httpClient.GetAsync($"http://localhost:7270/api/task/id={id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<ServiceTask>(data);
                if(task != null)
                {
                    var order = new Order { UserId = int.Parse(Request.Cookies["user_id"]), TaskId = task.Id  };
                    var json = JsonConvert.SerializeObject(order);
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await _httpClient.PostAsync("http://localhost:7270/api/order/add", httpContent);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectPermanent("/");
                    }
                }
            }
            return BadRequest();
        }
    }
}
