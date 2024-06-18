
using DB2.Interface.BasicInterface;
using DB2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2.Interface
{
    public interface ILesson : IBasicInterface<Lesson>
    {
        Task<List<Lesson>> GetAll();
        Task<List<Lesson>> GetAll(int idShedul);
        Task<List<Lesson>> GetAllUser(int userid);
        Task CreateAsync(string Description, Discipline discipline, MyUser teachers, Groups group, DateTime datatimestart, DateTime datatimeend, Sсhedule schedule);
        Task CreateAsync(string Description, int disciplineid, int teachersid, int groupid, DateTime datatimestart, DateTime datatimeend, int scheduleid);
        Task<bool> CrutchFindTryeOrFalse(int idUser, int idgroup);
        Task<List<Lesson>> GetLessonsByDisciplinesId(int DisId, int groupId);
    }
}
