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
    public class GroupsService : IGroups
    {
        private MyDB2context db;
        public GroupsService(MyDB2context _db)
        {
            db = _db;
        }
        public async Task addUserGroup(int IdGroups, int IdLearner)
        {

            var groupEntity = await db.Groups.FirstOrDefaultAsync(x => x.Id == IdGroups);
            var learnerEntity = await db.MyUser.FirstOrDefaultAsync(x => x.Id == IdLearner);

            if (groupEntity != null && learnerEntity != null)
            {
                groupEntity.MyUser.Add(learnerEntity);
                await db.SaveChangesAsync();
            }
            else
            {
               // throw new ArgumentException("Group or learner not found.");
            }


        }

        public async Task<bool> CreateAsync(Groups entity)
        {
            if (entity != null)
            {
                await db.Groups.AddAsync(entity);
                await db.SaveChangesAsync();
                return true;
            }
            else return false;
                //throw new NotImplementedException();

        }

        public async Task<Groups> FindGroup(string name)
        {
            if (name != null)
            {
                return await db.Groups.FirstOrDefaultAsync(x => x.Name.Equals(name));
            }
            else
                throw new NotImplementedException();
        }

        public async Task<List<Groups>> GetAll()
        {
            return await db.Groups.ToListAsync();
        }

        public async Task<Groups> GetAsync(int entityId)
        {
            return await db.Groups.FirstOrDefaultAsync(x => x.Id == entityId);
        }
        

        public async Task<Groups> GetGroupbyId(int id)
        {
            return await db.Groups
          .Include(x => x.MyUser)
          .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task RemoveAsync(int entityId)
        {
            var e = await GetAsync(entityId);
            db.Groups.Remove(e);
            await db.SaveChangesAsync();
        }

        public async void Update(Groups entity)
        {
            var attendance = db.Groups.Find(entity.Id);
            attendance = entity;
            db.SaveChanges();
        }
    }
}
