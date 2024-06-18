using Microsoft.EntityFrameworkCore;
using DB.Interface;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD.Model;

namespace DB.Repository
{
    public class SchedulesRepository : ISchedule
    {
        private MyDBcontext db;
        public SchedulesRepository(MyDBcontext _db)
        {
            db = _db;
        }
        public async Task CreateShedule(DateTime dateTime)
        {
            // var sched = await db.Schedules
            // можно продумать автосоздание по календарю
            var sched = new Sсhedule { dateTime = dateTime };
            //var datatimenow = dateTime.ToShortDateString();
            var DBsched = await db.Schedules.FirstOrDefaultAsync(x => x.dateTime.Date == dateTime); //DateTime.Now.Date);
            if (DBsched == null)
            {
            await db.AddAsync(sched);
            await db.SaveChangesAsync();
            }
        }

        public async Task<List<Sсhedule>> GetAll()
        {
            return await db.Schedules.Include(x=>x.Lessons).ToListAsync();
        }

        public async Task<List<Lesson>> GetAllLessons(int idshed)
        {


            ////var FindSched =  db.Schedules.FirstOrDefaultAsync(x=>x.Equals(idshed))


            //var FindSched = await db.Schedules.Include(x => x.Lessons .Where(x => x.Id.Equals(idshed)))
            //    .Where(x => x.Id.Equals(idshed))
            //    //.Include(x => x.Lessons).

            //    //.Include(x=>x.Discipline)
            //    //.Include(x => x.Teacher)
            //    //.Include(x=>x.Discipline)
            //    //.Include(x => x.Groups)
            //    .ToListAsync();
            //return  FindSched;
            var schedules = await db.Schedules
          .Include(x => x.Lessons)
                 .FirstOrDefaultAsync(x => x.Id == idshed);

            if (schedules != null)
            {
                return schedules.Lessons
                    
                    .ToList() ;
            }

            return new List<Lesson>();
        }

        public Task<Sсhedule> GetById(int idshed)
        {
            return  db.Schedules.Include(x=>x.Lessons)
                .FirstOrDefaultAsync(x => x.Id.Equals(idshed));
        }
    }
}
