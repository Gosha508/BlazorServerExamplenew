using System.Threading.Tasks;

namespace DB.Interface.BasicInterface
{ 
    public interface IAsyncRemoveRepository
    {
        Task RemoveAsync(int entityId);
    }
}
