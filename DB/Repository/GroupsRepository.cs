using Microsoft.EntityFrameworkCore;
using DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD.Model;

namespace DB.Repository
{
    public class GroupsRepository : IGroups
    {
        private MyDBcontext db;
        public GroupsRepository(MyDBcontext _db)
        {
            db = _db;
        }
        public async Task addLearnerGroup(Groups group, Learner learner)
        {
            var groupEntity = db.Groups.FirstOrDefault(g => g.Id == group.Id);
            var learnerEntity = db.Learners.FirstOrDefault(l => l.Id == learner.Id);

            if (groupEntity != null && learnerEntity != null)
            {
                groupEntity.Learners.Add(learnerEntity);
                await db.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Group or learner not found.");
            }
        }

        public async Task DeleteGroups(Groups groups)
        {
            if (groups == null)
            {
                throw new ArgumentNullException(nameof(groups));
            }
            db.Groups.Remove(groups);
            await db.SaveChangesAsync();
        }

        public async Task<List<Groups>> GetAll()
        {
          return await db.Groups
                
                .Include(x=>x.Learners)
                .ToListAsync();
        }



        public async Task GreateGroups(Discipline discipline, string name)
        {
            Groups groups = new Groups() {  Name = name };
            await db.Groups.AddAsync(groups);
            await db.SaveChangesAsync();
        }

        public async Task<Groups> GetGroupbyId(int id)
        {
            return await db.Groups
                 .Include(x => x.Learners) 
                 .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Groups> FindGroup(string name)
        {
            return await db.Groups.FirstOrDefaultAsync(x => x.Id.Equals(name));
        }
    }
}
