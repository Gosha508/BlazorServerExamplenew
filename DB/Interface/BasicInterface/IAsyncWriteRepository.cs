using System.Threading.Tasks;

namespace DB.Interface.BasicInterface
{
    public interface IAsyncWriteRepository<T> where T : class
    {
        Task CreateAsync(T entity);
    }
}
