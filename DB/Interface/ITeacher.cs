using BD.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Interface
{
    public interface ITeacher
    {
        Task CreateTeacher(string name, string email, string password);
        //Task CreateTeacher(MyUser myUser);
        Task<Teacher> LoginTeacher(string email, string password);
        Task NewTeacher(); //на удаление
        Task<List<Teacher>> GetAll();
        Task<Teacher> FindTeacher(string name);
        //Task<Teacher> GiveTeacher(MyUser user);
    }
}
