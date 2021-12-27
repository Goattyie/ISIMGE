using Common.Models;

namespace Website.Middleware
{
    public class CheackDataTaskMiddleware : AbstractMiddleware<ServiceTask>
    {
        public CheackDataTaskMiddleware(AbstractMiddleware<ServiceTask> next) : base(next) { }
        public async override Task Execute(ServiceTask obj)
        {
            if (obj.Price < 0)
                throw new Exception("Цена ниже нуля");
            if(obj.Name == string.Empty || obj.Name == null)
                throw new Exception("Название не указано");

            await Next?.Execute(obj);
        }
    }
}
