using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erep.ServiceLayer.Interfaces
{
    public interface _IGenericService<T> : IDisposable where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        T Find(Func<T, bool> predicate);
        IList<T> GetAll();
        IList<T> GetAll(Func<T, bool> predicate);

        T FindById(int id);
        void DeleteById(int id);

        //void Update(T entity);
    }
}
