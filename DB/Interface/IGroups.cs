using BD.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DB.Interface
{
    public interface IGroups
    {
        Task GreateGroups(Discipline discipline, string name);
        Task DeleteGroups(Groups groups);
        Task addLearnerGroup(Groups groups, Learner learner);
        Task<List<Groups>> GetAll();
        Task<Groups> GetGroupbyId(int id);
        Task<Groups> FindGroup(string name);
    }
}
