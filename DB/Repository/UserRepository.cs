using Microsoft.EntityFrameworkCore;
using DB.Interface;
using BD.Model;
using System.Threading.Tasks;
using DB.Interface.BasicInterface;

namespace DB.Repository
{
    public class UserRepository : ImyUser
    {
        private MyDBcontext db;
        public UserRepository(MyDBcontext _db)
        {
            db = _db;
        }

        public Task CreateAsync(MyUser entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateUser(string name, string email, string password)
        {
            var user = new MyUser() { Name = name, Email = email, Password = password, Role = "L" };
            await db.MyUser.AddAsync(user);
            await db.SaveChangesAsync();
            
        }
        public async Task<MyUser>CreateUser1(string name, string email, string password) //test
        {
            var user = new MyUser() { Name = name, Email = email, Password = password, Role = "L" };
            await db.MyUser.AddAsync(user);
            await db.SaveChangesAsync();
            return user;

        }

        public Task<MyUser> GetAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MyUser> GetUser1(int id) //test
        {
            var user = await db.MyUser.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
        public async Task GiveRoleTeacher()
        {
            //var user = await db.MyUser.FirstOrDefaultAsync(x => x.Equals(AutUser.UserOnline));
            //user.Role = "T";
            //await db.SaveChangesAsync(true);
            //AutUser.UserOnline = await db.MyUser.FirstOrDefaultAsync(x => x.Equals(user));
        }
        public async Task<MyUser> LoginUser(string email, string password)
        {
            var user = await db.MyUser.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            //var teacher = await db.Teachers.FirstOrDefaultAsync(x => x.MyUser.Id.Equals(user.Id));
            //var learner = await db.Learners.FirstOrDefaultAsync(x => x.MyUser.Id.Equals(user.Id));
        //    AutUser.UserOnline = user;
            //AutUser.Userlearner = learner;
            //AutUser.UserTeacher = teacher;
       
            return user;
        }

        public Task RemoveAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(MyUser entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
