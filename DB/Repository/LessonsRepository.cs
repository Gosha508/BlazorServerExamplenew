using Microsoft.EntityFrameworkCore;
using DB.Interface;
using BD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Repository
{
    public class LessonsRepository : ILesson
    {
        private readonly MyDBcontext _dbContext;
        public LessonsRepository(MyDBcontext myDBcontext)
        {
            _dbContext = myDBcontext;
        }
        public async Task CreateLesson(string Description, Discipline discipline, Teacher teachers, Groups group , DateTime timestart, DateTime timeend, Sсhedule schedule )//после добавить место проведения
        {
            var s = new Lesson
            { 
                Description = Description ,
                Groups = group, 
                Discipline = discipline, 
                Teacher = teachers , 
                //TimeStart = timestart, 
                //TimeEnd = timeend , 
                Sсhedule = schedule
                //dateTime =d
            };
            await _dbContext.AddAsync(s);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Lesson>> GetAll()
        {
            return await _dbContext.Lessons
                 .Include(s => s.Discipline)
                  .Include(s => s.Groups)
                    
                     .Include(s => s.Teacher)
                    //.OrderBy(s => s.dateTime)
                .ToListAsync();
        }

        public async Task<Lesson> GetById(int id)
        {
            return await _dbContext.Lessons
                .Include(x => x.Teacher)
                .Include(x=>x.Groups)
                .ThenInclude(x=>x.Learners)

                .FirstOrDefaultAsync(x=>x.Id.Equals(id));
        }
    }
}
