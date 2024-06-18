
using DB2.Interface.BasicInterface;
using DB2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2.Interface
{
    public interface IAttendance : IBasicInterface<Attendance>
    {
        Task CreateAttendance(int idSchedules, int idLearner, bool IsPresent, string Description);
        Task<List<Attendance>> GetListAttendances(int idShedul);
        Task<Attendance> GetAttendance(int idshed, int idleaarn);
        Task<Attendance> GetAttendanceFromleaarn(int idleaarn);
        Task<List<Attendance>> GetAttenUser(int userId);
        Task<List<Attendance>> GetAttendanceFromUser(int iduser, int iddis);
    }
}
