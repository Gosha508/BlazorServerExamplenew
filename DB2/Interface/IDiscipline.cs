
using DB2.Interface.BasicInterface;
using DB2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2.Interface
{
   public interface IDiscipline : IBasicInterface<Discipline>
    {
        Task<List<Discipline>> GetAll();
        Task<Discipline> FindDis(string name);
    }
}
