using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB2.Model;
using DB2.Interface;
using Microsoft.EntityFrameworkCore;
using DB2.Interface.BasicInterface;
using System.Runtime.CompilerServices;

namespace DB2.Services
{
    public class ScheduleService : ISchedule
    {
        private MyDB2context db;
        public ScheduleService(MyDB2context _db)
        {
            db = _db;
        }

        public async Task<bool> CreateAsync(Sсhedule entity)
        {
            if (entity != null)
            {
                await db.Schedules.AddAsync(entity);
                await db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
               // throw new NotImplementedException();
        }

        public async Task<Sсhedule> FindData(DateTime dateTime)
        {
          return await  db.Schedules.FirstOrDefaultAsync(s => s.dateTime == dateTime);
        }

        public async Task<List<Sсhedule>> GetAll()
        {
            return await db.Schedules.ToListAsync();
        }
        public async Task<List<Sсhedule>> GetdataTime(DateTime dateToDay)
        {
              //DateTime dateToDay = DateTime.Today;
              var s = dateToDay - TimeSpan.FromDays(dateToDay.DayOfWeek == DayOfWeek.Sunday ? 6 : (byte)dateToDay.DayOfWeek - 1);
            // s <= t && t <= f
            var f = s + TimeSpan.FromDays(6);

            return await db.Schedules
                .Include(x => x.Lessons)
                .ThenInclude(x => x.Groups)
                .Include(x => x.Lessons)
                .ThenInclude(x => x.Discipline)
                .Where(t=> s <= t.dateTime && t.dateTime <= f)
                .ToListAsync();

            //return null; 
        }
        public async Task<List<Lesson>> GetAllLessons(int idSched)
        {
            var list = await db.Schedules
                .Include(x => x.Lessons)
                .ThenInclude(x => x.Discipline)
                .Include(x => x.Lessons)
                .ThenInclude(x => x.Groups)
                .Include(x => x.Lessons)
                .ThenInclude(x => x.MyUser)

                .FirstOrDefaultAsync(x => x.Id == idSched);
            if (list != null)
            {
                return list.Lessons.ToList();
            }
            else return null;
        }

        public async Task<Sсhedule> GetAsync(int entityId)
        {
            return await db.Schedules.FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public async Task RemoveAsync(int entityId)
        {
            var e = await GetAsync(entityId);
            db.Schedules.Remove(e);
            await db.SaveChangesAsync();
        }



        public void Update(Sсhedule entity)
        {
            var attendance = db.Schedules.Find(entity.Id);
            attendance = entity;
            db.SaveChanges();
        }

       
    }
}
