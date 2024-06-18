
using BD.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB.Interface
{
    public interface IDiscipline
    {
        Task CreateNewDiscipline(string name);
        Task DeleteDiscipline(Discipline discipline );

        Task<List<Discipline>> GetAll();

        Task<Discipline> FindDis(string name);
    }
}
