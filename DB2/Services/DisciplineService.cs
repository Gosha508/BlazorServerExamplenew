using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DB2.Interface;
using DB2.Model;
using Microsoft.EntityFrameworkCore;

namespace DB2.Services
{
    public class DisciplineService : IDiscipline
    {
        private MyDB2context db;
        public DisciplineService(MyDB2context _db)
        {
            db = _db;
        }
        public async Task<bool> CreateAsync(Discipline entity)
        {
            if (entity != null && entity.Name != null)
            {
                await db.Disciplines.AddAsync(entity);
                await db.SaveChangesAsync();
                return true;
            }
            else return false;
               // throw new NotImplementedException();
        }

        public async Task<Discipline> FindDis(string name)
        {
            if(name != null)
            {
                return  await db.Disciplines.FirstOrDefaultAsync(x => x.Name.Equals(name));
            } else
            throw new NotImplementedException();
        }

        public async Task<List<Discipline>> GetAll()
        {
            return await db.Disciplines.ToListAsync();
            
        }

        public async Task<Discipline> GetAsync(int entityId)
        {
            return await db.Disciplines.FirstOrDefaultAsync(x => x.Id == entityId);
           // throw new NotImplementedException();
        }

        public async Task RemoveAsync(int entityId)
        {
            var e = await GetAsync(entityId);
            db.Disciplines.Remove(e);
            await db.SaveChangesAsync();
           // throw new NotImplementedException();
        }

        public void Update(Discipline entity)
        {
            var attendance = db.Disciplines.Find(entity.Id);
            attendance = entity;
            db.SaveChanges();
        }
    }
}
