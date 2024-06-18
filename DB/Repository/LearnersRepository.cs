using Microsoft.EntityFrameworkCore;
using DB.Interface;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD.Model;

namespace DB.Repository
{
    public class LearnersRepository : ILearner
    {
        private MyDBcontext db;
        public LearnersRepository(MyDBcontext db)
        {
            this.db = db;
        }


        public async Task CreateLearner(string name, string email, string password)
        {
            var user = new Learner() { Name = name, Email = email, Password = password, Role = "Learner" };
            await db.Learners.AddAsync(user);
            await db.SaveChangesAsync();
        }

        public async Task<List<Learner>> GiveLearner(string name)
        {
            return await db.Learners.Where(x => x.Name.Contains(name) && x.Role == "Learner").Take(5).ToListAsync();
        }

        public async Task CreateLearner(MyUser user) //  робит просто забыл асинхронность
        {
            //var findLearner = await db.Learners.FirstOrDefaultAsync(x => x.MyUser.Id.Equals(user.Id));
            //if (findLearner == null)
            //{
            //    Learner learner = new Learner() { MyUser = user, Id = user.Id };
            //    await db.Learners.AddAsync(learner);
            //    await db.SaveChangesAsync();
            //}

        }

        public Task<Learner> GiveLearner(MyUser user)
        {
            throw new System.NotImplementedException();
        }
        //public async Task<Learner> GiveLearner(MyUser user)
        //{
        //    //var findLearner = db.Learners.FirstOrDefaultAsync(x => x.MyUser.Id.Equals(user.Id));
        //    //return await findLearner;
        //}
    }
}
