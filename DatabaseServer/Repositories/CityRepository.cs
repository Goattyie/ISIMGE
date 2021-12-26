using Common.Models;
using DatabaseServer.Database;

namespace DatabaseServer.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private readonly PostgresConnection _db;

        public CityRepository(PostgresConnection db)
        {
            _db = db;
        }
        public async Task Add(City obj)
        {
            await _db.Cities.AddAsync(obj);
        }

        public Task Delete(City obj)
        {
            _db.Cities.Remove(obj);
            return Task.CompletedTask;
        }

        public async Task Dispose()
        {
            await _db.DisposeAsync();
        }

        public City? Get(int id)
        {
            return _db.Cities.SingleOrDefault(x=>x.Id == id);
        }

        public IEnumerable<City> GetAll()
        {
            return _db.Cities.AsEnumerable();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
