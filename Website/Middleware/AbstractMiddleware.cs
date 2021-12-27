namespace Website.Middleware
{
    public abstract class AbstractMiddleware <T> where T : class
    {
        private AbstractMiddleware<T> next;
        public AbstractMiddleware(AbstractMiddleware<T> next)
        {
            this.next = next;
        }
        public AbstractMiddleware() { }
        protected AbstractMiddleware<T> Next => next;
        public abstract Task Execute(T obj);
    }
}
