using BD.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Interface
{
    public interface ISchedule
    {
        Task CreateShedule( DateTime dateTime);
        Task<List<Sсhedule>> GetAll();
        Task<List<Lesson>> GetAllLessons(int idSched);
        Task<Sсhedule> GetById(int id);
    }
}
