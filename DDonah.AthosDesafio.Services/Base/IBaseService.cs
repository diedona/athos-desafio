using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DDonah.AthosDesafio.Services.Base
{
    public interface IBaseService<T>
    {
        void Save(T entity);
        void Delete(int id);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T entity);
        bool Exists(Expression<Func<T, bool>> condition);
    }
}
