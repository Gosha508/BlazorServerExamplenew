using System.Threading.Tasks;

namespace DB.Interface.BasicInterface
{
    public interface IAsyncReadRepository<T> where T : class
    {
        Task<T?> GetAsync(int entityId);
    }
}
