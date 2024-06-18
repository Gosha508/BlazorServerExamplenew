using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB2.Model;
using DB2.Interface;
using Microsoft.EntityFrameworkCore;
namespace DB2.Services
{
    public class LessonService : ILesson
    {
        private MyDB2context db;
        public LessonService(MyDB2context _db)
        {
            db = _db;
        }

        public async Task<bool> CreateAsync(Lesson entity)
        {
            if (entity != null)
            {
                await db.Lessons.AddAsync(entity);
                await db.SaveChangesAsync();
                return true;
            }
            else return false;
            //  throw new NotImplementedException();
        }
        public async Task CreateAsync(string Description, Discipline discipline, MyUser teachers, Groups group, DateTime datatimestart, DateTime datatimeend, Sсhedule schedule)
        {
            var s = new Lesson
            {
                Description = Description,
                Groups = group,
                Discipline = await db.Disciplines.FirstOrDefaultAsync(x=>x.Id == discipline.Id),
                MyUser = teachers,
                TimeStart = datatimestart,
                TimeEnd = datatimeend,
                Sсhedule = schedule
                //dateTime =d
            };
            await db.AddAsync(s);
            await db.SaveChangesAsync();
        }
        public async Task CreateAsync(string Description, int disciplineid, int teachersid, int groupid, DateTime datatimestart, DateTime datatimeend, int scheduleid)
        {
            var s = new Lesson
            {
                Description = Description,
                Groups = await db.Groups.FirstOrDefaultAsync(x => x.Id == groupid),
                Discipline = await db.Disciplines.FirstOrDefaultAsync(x => x.Id == disciplineid),
                MyUser = await db.MyUser.FirstOrDefaultAsync(x => x.Id == teachersid),
                TimeStart = datatimestart,
                TimeEnd = datatimeend,
                Sсhedule = await db.Schedules.FirstOrDefaultAsync(x => x.Id == scheduleid)
                //dateTime =d
            };
            await db.AddAsync(s);
            await db.SaveChangesAsync();
        }
        public async Task<List<Lesson>> GetAll()
        {
            return await db.Lessons.ToListAsync();
        }

        public async Task<List<Lesson>> GetAll(int idShedul)
        {
            return await db.Lessons.Include(x=>x.Sсhedule).Include(x => x.Groups).Include(x => x.Discipline).Where(x=>x.Sсhedule.Id == idShedul) .ToListAsync();
        }
        public async Task<List<Lesson>> GetAllUser(int idUser)
        {
            var x =
             await db.Lessons.Include(x=>x.Sсhedule).Include(x=>x.Groups).Include(x=>x.Discipline).Where(x=>x.MyUser.Id == idUser).ToListAsync();
            return x;
        }
        public async Task<Lesson> GetAsync(int entityId)
        {
            return await db.Lessons.Include(x=>x.Groups)
                .ThenInclude(x=>x.MyUser)
                .Include(x=>x.MyUser)
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public async Task RemoveAsync(int entityId)
        {
            var e = await GetAsync(entityId);
            db.Lessons.Remove(e);
            await db.SaveChangesAsync();
        }

        public  void Update(Lesson entity)
        {
            var attendance = db.Lessons.Find(entity.Id);
            attendance = entity;
            db.SaveChanges();
        }

        public async Task<bool> CrutchFindTryeOrFalse(int idUser, int idgroup)
        {
        var group = await db.Groups.Include(x=>x.MyUser).FirstOrDefaultAsync(x => x.Id == idgroup);
            return  group.MyUser.Any(x => x.Id == idUser);
             
            
        }
        public async Task<List<Lesson>> GetLessonsByDisciplinesId(int DisId, int groupId)
        {
            if (DisId == 0 || groupId == 0) return null;

            return await db.Lessons 
                .Include(x=>x.Discipline)
                .Include(x=>x.Groups)
                
                .Where(x=>x.Discipline.Id == DisId && x.Groups.Id == groupId)
                .ToListAsync();
                
                
        }
    }
}
