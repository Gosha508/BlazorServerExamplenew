using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB2.Interface.BasicInterface
{
   public interface IBasicInterface<T> where T : class
    {
        Task<bool> CreateAsync(T entity);
        void Update(T entity);
        Task<T?> GetAsync(int entityId);
        Task RemoveAsync(int entityId);
    }
}
