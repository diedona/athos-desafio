using DDonah.AthosDesafio.Infra.Generated;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DDonah.AthosDesafio.Services.Base
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly AthosDesafioContext _db;
        protected DbSet<T> _dbSet => _db.Set<T>();

        public BaseService(AthosDesafioContext db)
        {
            _db = db;
        }

        public virtual void Save(T entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
            _db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            T entity = _db.Set<T>().Find(id);
            if (entity == null)
            {
                return;
            }

            _dbSet.Remove(entity);
            _db.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T Get(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
