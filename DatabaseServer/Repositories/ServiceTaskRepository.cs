using Common.Models;
using DatabaseServer.Database;

namespace DatabaseServer.Repositories
{
    public class ServiceTaskRepository : IRepository<ServiceTask>
    {
        private readonly PostgresConnection _db;

        public ServiceTaskRepository(PostgresConnection db)
        {
            _db = db;
        }
        public async Task Add(ServiceTask obj)
        {
            await _db.Tasks.AddAsync(obj);
        }

        public Task Delete(ServiceTask obj)
        {
            throw new NotImplementedException();
        }

        public async Task Dispose()
        {
            await _db.DisposeAsync();
        }

        public ServiceTask? Get(int id)
        {
            return _db.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ServiceTask> GetAll()
        {
            return _db.Tasks.AsEnumerable();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
