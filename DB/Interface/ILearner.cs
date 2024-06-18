using BD.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Interface
{
    public interface ILearner
    {
        Task CreateLearner(string name, string email, string password);
        Task<List<Learner>>  GiveLearner(string name);
         Task CreateLearner(MyUser user);
        //Task<Learner> GiveLearner(MyUser user);
    }
}
