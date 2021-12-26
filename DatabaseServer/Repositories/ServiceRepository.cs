using Common.Models;
using DatabaseServer.Database;

namespace DatabaseServer.Repositories
{
    public class ServiceRepository : IRepository<Service>
    {
        private readonly PostgresConnection _db;

        public ServiceRepository(PostgresConnection db)
        {
            _db = db;
        }
        public async Task Add(Service obj)
        {
            await _db.Services.AddAsync(obj);
        }

        public Task Delete(Service obj)
        {
            throw new NotImplementedException();
        }

        public Task Dispose()
        {
            throw new NotImplementedException();
        }

        public Service? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetAll()
        {
            return _db.Services.AsEnumerable();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
