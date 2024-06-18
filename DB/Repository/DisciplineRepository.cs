using Microsoft.EntityFrameworkCore;
using DB.Interface;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BD.Model;

namespace DB.Repository
{
    public class DisciplineRepository : IDiscipline
    {
        private MyDBcontext db;
        public DisciplineRepository(MyDBcontext _db)
        {
            db = _db;
        }
        public async Task CreateNewDiscipline(string name)
        {
            var discipline = new Discipline() { Name = name };
            await db.AddAsync(discipline);
            await db.SaveChangesAsync();
        }

        public async Task DeleteDiscipline(Discipline discipline)
        {
            if (discipline == null)
            {
                throw new ArgumentNullException(nameof(discipline));
            }

            db.Disciplines.Remove(discipline);
            await db.SaveChangesAsync();
        }

        public async Task<Discipline> FindDis(string name)
        {
          return await db.Disciplines.FirstOrDefaultAsync(x=>x.Name == name);
        }

        public async Task<List<Discipline>> GetAll()
        {
            return await db.Disciplines.ToListAsync();
        }
    }
}
