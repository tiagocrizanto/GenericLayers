using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.Shared.DomainServices
{
    public interface IBaseService<Entity, TContext> where Entity : class where TContext : DbContext
    {
        void Add(Entity obj);
        void Add(IList<Entity> obj);
        Entity GetById(int id);
        Entity GetById(Guid id);
        void Update(Entity obj);
        void Delete(Entity obj);
        void Delete(IList<Entity> obj);
        Entity FindFirstOrDefault(Expression<Func<Entity, bool>> match);
        IQueryable<Entity> GetAll();
        IQueryable<Entity> GetAll(Expression<Func<Entity, bool>> match);
        void Dispose();
    }
}