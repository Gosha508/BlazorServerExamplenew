
using DB2.Interface.BasicInterface;
using DB2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2.Interface
{
 public   interface IGroups :  IBasicInterface<Groups>
    {
        Task addUserGroup(int IdGroups, int IdLearner);
        Task<List<Groups>> GetAll();
        Task<Groups> GetGroupbyId(int id);
        Task<Groups> FindGroup(string name);
    }
}
