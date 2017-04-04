using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.Shared.Data.Repository
{
    public interface IBaseRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        void Add(TEntity obj);
        void Add(IList<TEntity> list);
        TEntity GetById(int id);
        TEntity GetById(Guid id);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Remove(IList<TEntity> obj);
        TEntity FindFirstOrDefault(Expression<Func<TEntity, bool>> match);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> match);
        void Dispose();
    }
}
