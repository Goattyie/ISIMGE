namespace DatabaseServer.Repositories
{
    public interface IRepository <T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T? Get(int id);
        public Task Add(T obj);
        public Task Delete(T obj);
        public Task Dispose();
        public Task SaveAsync();
    }
}
