using Common.Models;
using DatabaseServer.Database;
using Microsoft.EntityFrameworkCore;

namespace DatabaseServer.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly PostgresConnection _db;

        public OrderRepository(PostgresConnection db)
        {
            _db = db;
        }
        public async Task Add(Order obj)
        {
            await _db.Orders.AddAsync(obj);
        }

        public Task Delete(Order obj)
        {
            throw new NotImplementedException();
        }

        public async Task Dispose()
        {
            await _db.DisposeAsync();
        }

        public Order? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.Include(o=>o.Task).AsEnumerable();
        }

        public IEnumerable<Order> GetAll(int userId)
        {
            return _db.Orders.Include(o => o.Task).Where(x=>x.UserId == userId).AsEnumerable();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
