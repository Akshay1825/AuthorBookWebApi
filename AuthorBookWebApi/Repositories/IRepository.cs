namespace AuthorBookWebApi.Repositories
{
    public interface IRepository<T>
    {
        public int Add(T entity);
        public T Update(T entity);
        public void Delete(T entity);
        public T Get(int id);
        public IQueryable<T> GetAll();
    }
}
