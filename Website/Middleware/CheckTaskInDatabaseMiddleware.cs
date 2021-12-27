using Common.Models;
using Newtonsoft.Json;

namespace Website.Middleware
{
    public class CheckTaskInDatabaseMiddleware : AbstractMiddleware<ServiceTask>
    {
        private HttpClient _httpClient = new();
        public override async Task Execute(ServiceTask obj)
        {
            var response = await _httpClient.GetAsync($"http://localhost:7270/api/task/name={obj.Name}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var task = JsonConvert.DeserializeObject<ServiceTask>(data);
                if (task == null)
                {
                    Next?.Execute(obj);
                }
                else throw new Exception("Услуга уже была создана");
            }
        }
    }
}
