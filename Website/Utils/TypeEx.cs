using Common.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Website.Utils
{
    public static class TypeEx
    {
        public static IEnumerable<Service> AsServiceList(this string data)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Service>>(data);
        }
        public static IEnumerable<ServiceTask> AsServiceTaskList(this string data)
        {
            return JsonConvert.DeserializeObject<IEnumerable<ServiceTask>>(data);
        }
    }
}
