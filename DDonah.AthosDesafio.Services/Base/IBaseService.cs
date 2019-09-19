using System;
using System.Collections.Generic;
using System.Text;

namespace DDonah.AthosDesafio.Services.Base
{
    public interface IBaseService<T>
    {
        void Save(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
