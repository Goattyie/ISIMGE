using Website.Database;
using Website.Models;

namespace Website.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly PostgresContext _db;

        public AccountRepository(PostgresContext db)
        {
            _db = db;
        }
        public async Task Add(Account obj)
        {
            await _db.Accounts.AddAsync(obj);
        }

        public Task Delete(Account obj)
        {
            throw new NotImplementedException();
        }

        public async Task Dispose()
        {
            await _db.DisposeAsync();
        }

        public Account Get(int id)
        {
            throw new NotImplementedException();
        }

        public Account Get(string login)
        {
            return _db.Accounts.FirstOrDefault(x => x.Login == login);
        }

        public IEnumerable<Account> GetAll()
        {
            return _db.Accounts.AsEnumerable();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
