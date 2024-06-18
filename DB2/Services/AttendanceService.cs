
using DB2;
using DB2.Interface;
using DB2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2.Services
{
    public class AttendanceService : IAttendance
    {
        private MyDB2context db;
        public AttendanceService(MyDB2context _db)
        {
            db = _db;
        }
        public async Task<bool> CreateAsync(Attendance entity)
        {
            if (entity != null)
            {
                await db.Attendances.AddAsync(entity);
                await db.SaveChangesAsync();
                return true;
            }
            else return false;
               // throw new NotImplementedException();
        }

        public async Task<Attendance> GetAsync(int entityId)
        {

            return await db.Attendances.FirstOrDefaultAsync(x => x.Id == entityId);
            //   throw new NotImplementedException();
        }
        public async Task<List<Attendance>> GetAttenUser(int userId)
        {
            return await db.Attendances
                .Include(x => x.Lesson)
                .ThenInclude(x => x.Discipline)
                .Where(x => x.MyUser.Id == userId)
                .Include(x => x.Lesson)
                .ThenInclude(x => x.Sсhedule)
                // .AsNoTracking() //на случай если будет ругатся что типо уже ослеживаю данную
                .ToListAsync();
               
            //   throw new NotImplementedException();
        }
        public async Task<List<Attendance>> GetListAttendances(int idLesson)
        {

            return await db.Attendances.Include(x => x.Lesson).Where(x => x.Lesson.Id == idLesson).ToListAsync();

        }


        public async Task RemoveAsync(int entityId)
        {
            var e = await GetAsync(entityId);
             db.Attendances.Remove(e);
            await db.SaveChangesAsync();
           // throw new NotImplementedException();
        }

        public void Update(Attendance entity)
        {
            db.Entry(entity).State = EntityState.Modified;
             db.SaveChanges();
            //var attendance = db.Attendances.Find(entity.Id);
            //attendance = entity;
            //db.SaveChanges();
        }

        public async Task<Attendance> GetAttendance(int idshed, int idleaarn)
        {
            var Attendance = await db.Attendances
                .Include(x => x.Lesson)
                .Include(x => x.MyUser)
                .FirstOrDefaultAsync(x => x.Lesson.Id == idshed && x.MyUser.Id == idleaarn);
            return Attendance;
        }
        public async Task<Attendance> GetAttendanceFromleaarn(int idleaarn)
        {
            var Attendance = await db.Attendances
                .Include(x => x.Lesson)
                .Include(x => x.MyUser)
                .FirstOrDefaultAsync(x =>  x.MyUser.Id == idleaarn);
            return Attendance;
        }
        public async Task<List<Attendance>> GetAttendanceFromUser(int iduser, int iddis)
        {
            var Attendance = await db.Attendances
                .Include(x => x.MyUser)
                .Include(x => x.Lesson).ThenInclude(x => x.Discipline)
                .Where(x=>x.MyUser.Id == iduser && x.Lesson.Discipline.Id ==iddis)
                .ToListAsync();
                
            return Attendance;
        }
        public async Task CreateAttendance(int idLesson, int idLearner, bool IsPresent, string Description)
        {

            var Lesson = await db.Lessons.FirstOrDefaultAsync(x => x.Id.Equals(idLesson));
            var Learner = await db.MyUser.FirstOrDefaultAsync(x => x.Id.Equals(idLearner));
            var atterdancre = new Attendance() { Lesson = Lesson, MyUser = Learner, IsPresent = IsPresent, Description = Description , Grades = "0"};
            db.Attendances.Add(atterdancre);
            await db.SaveChangesAsync();
        }
    }
}
