using Microsoft.EntityFrameworkCore;
using DB.Interface;
using BD.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Repository
{
    public class AttendanceRepository : IAttendance
    {
        private MyDBcontext db;
        public AttendanceRepository(MyDBcontext _db)
        {
            db = _db;
        }
        public async Task CreateAttendance(int idLesson, int idLearner , bool IsPresent, string Description)
        {
            var Lesson = await db.Lessons.FirstOrDefaultAsync(x => x.Id.Equals(idLesson));
            var Learner = await db.Learners.FirstOrDefaultAsync(x => x.Id.Equals(idLearner));
            var atterdancre = new Attendance() { Lesson = Lesson, Learner = Learner , IsPresent = IsPresent, Description = Description};
            db.Attendances.Add(atterdancre);
           await  db.SaveChangesAsync();
        }

        public async Task<Attendance> GetAttendance(int id)
        {
            var Attendance = await db.Attendances.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return Attendance;
        }

        public async Task<Attendance> GetAttendance(int idshed, int idleaarn)
        {
            var Attendance = await db.Attendances
                .Include(x=>x.Lesson)
                .Include(x => x.Learner)
                .FirstOrDefaultAsync(x => x.Lesson.Id == idshed && x.Learner.Id == idleaarn);
            return Attendance;
        }

        public async Task<List<Attendance>> GetListAttendances(int idShedul)
        {
            return await db.Attendances.Include(x=>x.Lesson).Where(x => x.Lesson.Id == idShedul).ToListAsync();
        }

        public async Task  UpdateAttendance(Attendance attendance)
        {
             db.Entry(attendance).State = EntityState.Modified;
           await  db. SaveChangesAsync();

        }
    }
}
