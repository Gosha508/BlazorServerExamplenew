using BD.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Interface
{
    public interface IAttendance
    {
        Task CreateAttendance(int idSchedules, int idLearner, bool IsPresent, string Description);
        Task UpdateAttendance(Attendance attendance);
        Task<Attendance> GetAttendance(int id);
        Task<Attendance> GetAttendance(int idshed, int idleaarn);
        Task<List<Attendance>> GetListAttendances(int idShedul);
    }
}
