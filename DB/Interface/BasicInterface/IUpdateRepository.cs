namespace DB.Interface.BasicInterface
{
    public interface IUpdateRepository<T> where T : class
    {
        void Update(T entity);
    }
}
