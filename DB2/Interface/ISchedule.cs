
using DB2.Interface.BasicInterface;
using DB2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2.Interface
{
    public interface ISchedule : IBasicInterface<Sсhedule>
    {
        Task<List<Sсhedule>> GetAll();
        Task<List<Lesson>> GetAllLessons(int idSched);
        Task <Sсhedule> FindData(DateTime dateTime);
        Task<List<Sсhedule>> GetdataTime(DateTime dateToDay);

    }
}
