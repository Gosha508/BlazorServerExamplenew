using BD.Model;

using DB.Interface.BasicInterface;
using System.Threading.Tasks;

namespace DB.Interface
{
    public interface ImyUser : IAsyncRepository<MyUser>
    {
        Task CreateUser(string name, string email, string password);
        Task<MyUser> CreateUser1(string name, string email, string password);
        Task<MyUser> GetUser1(int id);
        Task<MyUser> LoginUser(string email, string password);

    }
}
