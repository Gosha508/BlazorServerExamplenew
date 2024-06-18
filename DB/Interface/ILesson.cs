using BD.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Interface
{
    public interface ILesson
    {
        //Task CreateLesson(string Description);
        Task CreateLesson(string Description, Discipline discipline, Teacher teachers , Groups group, DateTime datatimestart, DateTime datatimeend, Sсhedule schedule);
        Task<List<Lesson>> GetAll();

        Task<Lesson> GetById( int id );
    }
}
