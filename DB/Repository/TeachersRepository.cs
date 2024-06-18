using Microsoft.EntityFrameworkCore;

using DB.Interface;
using BD.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Repository
{
    public class TeachersRepository : ITeacher 
    {
        private MyDBcontext db;
        public TeachersRepository(MyDBcontext _db)
        {
            db = _db;
        }
        public async Task CreateTeacher(string name, string email, string password)
        {
            var user = new Teacher() { Name = name, Email = email, Password = password, Role = "Teacher" };
            await db.Teachers.AddAsync(user);
            await db.SaveChangesAsync();
        }

        //public async Task<Teacher> LoginTeacher(string email, string password)
        //{
        //    //var user = await db.Teachers.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        //    //AutUser.UserOnline = user;
        //    //return user;
        //}

        public async Task NewTeacher()
        {
            //var user = await db.MyUser.FirstOrDefaultAsync(x => x.Equals(AutUser.UserOnline));
            //user.Role = "Teacher";
            ////user.Discriminator = "Teacher"
            //await db.SaveChangesAsync(true);
            //AutUser.UserOnline = await db.MyUser.FirstOrDefaultAsync(x => x.Equals(user));

        }
        public async Task<Teacher> FindTeacher(string name)
        {
            return await db.Teachers.FirstOrDefaultAsync(x => x.Id.Equals(name));
        }
        public async Task<List<Teacher>> GetAll()
        {
            return await db.Teachers.ToListAsync();
        }
        public Task<Teacher> LoginTeacher(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateTeacher(MyUser user)
        {
            //var findTeacher = await db.Teachers.FirstOrDefaultAsync(x => x.MyUser.Id.Equals(user.Id));
            //if (findTeacher == null)
            //{
            //    var teacher = new Teacher() { MyUser = user, Id = user.Id };
            //    await db.Teachers.AddAsync(teacher);
            //    await db.SaveChangesAsync();
            //}

        }
        //public async Task<Teacher> GiveTeacher(MyUser user)
        //{
        //    var findTeacher = db.Teachers.FirstOrDefaultAsync(x => x.MyUser.Id.Equals(user.Id));
        //    return await findTeacher;
        //}
    }
}

