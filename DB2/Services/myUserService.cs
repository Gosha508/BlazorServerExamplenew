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
    public class MyUserService : IMyUser
    {
        private MyDB2context db;
        public MyUserService(MyDB2context _db)
        {
            db = _db;
        }

        public async Task<bool> CreateAsync(MyUser entity)
        {
            var x = db.MyUser.Any(x => x.Email == entity.Email);

            if (entity != null && x == false && entity.Email != null && entity.Name != null && entity.Password != null)
            {
                await db.MyUser.AddAsync(entity);
                await db.SaveChangesAsync();
                return true;
            }
            else
            {
                Console.WriteLine("Register CreateAsync EROR");
                return false;
                
                // throw new NotImplementedException();
            }


        }

        public async Task<List<MyUser>> GetAllTeacher()
        {
            return await db.MyUser.Where(x=>x.Role =="T").ToListAsync();
        }

        public async Task<MyUser> GetAsync(int entityId)
        {
            return await db.MyUser.FirstOrDefaultAsync(x => x.Id == entityId);
        }
        public async Task <List<MyUser>> GetAsyncString(string name)
        {
            return await db.MyUser.Where(x => x.Name.Contains(name) && x.Role == "L").Take(5).ToListAsync();
        }
        public async Task <List<MyUser>> GetGroupList(int idGroup)
        {
            return await db.MyUser.Where(x => x.Groups.Id.Equals(idGroup)).ToListAsync();
        }
        public async Task<MyUser> LoginUser(string email, string password)
        {

            if (email != null && password != null)
            {
                var user = await db.MyUser.Include(x=>x.Groups).FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
                if (user != null)
                {
                    return user;
                }
                else return null;

            }
            else return null;
            // throw new NotImplementedException();

        }

        public async Task RemoveAsync(int entityId)
        {
            var e = await GetAsync(entityId);
            db.MyUser.Remove(e);
            await db.SaveChangesAsync();
        }

        public void Update(MyUser entity)
        {
            var attendance = db.MyUser.Find(entity.Id);
            attendance = entity;
            db.SaveChanges();
        }
    }
}
