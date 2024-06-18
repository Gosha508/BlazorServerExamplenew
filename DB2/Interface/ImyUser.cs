
using System.Collections.Generic;
using System.Threading.Tasks;
using DB2.Interface.BasicInterface;
using DB2.Model;

namespace DB2.Interface
{
    public interface IMyUser  : IBasicInterface<MyUser>
    {
        // CreateUser(MyUser MyUser);
        //Task<MyUser> LoginUser();
        
        //Task CreateUser(string name, string email, string password);
        //Task<MyUser> CreateUser1(string name, string email, string password);
        //Task<MyUser> GetUser1(int id);
        Task<MyUser> LoginUser(string email, string password);
        Task<List<MyUser>> GetGroupList(int idGroup);
        Task<List<MyUser>> GetAsyncString(string name);
        Task<List<MyUser>> GetAllTeacher();
    }
}
