using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.Shared.Data.Repository
{
    public class BaseRepository<Entity, TContext> : IDisposable, IBaseRepository<Entity, TContext> where Entity : class where TContext : DbContext
    {
        private readonly TContext _tcontext;

        public BaseRepository(TContext tcontext)
        {
            _tcontext = tcontext;
        }

        public void Add(Entity obj)
        {
            try
            {
                _tcontext.Set<Entity>().Add(obj);
                _tcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error to add", ex);
            }
        }

        public void Add(IList<Entity> list)
        {
            try
            {
                _tcontext.Set<Entity>().AddRange(list);
                _tcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error to add", ex);
            }
        }

        public IQueryable<Entity> GetAll()
        {
            return _tcontext.Set<Entity>();
        }

        public IQueryable<Entity> GetAll(Expression<Func<Entity, bool>> match)
        {
            return _tcontext.Set<Entity>().Where(match);
        }

        public Entity GetById(int id)
        {
            return _tcontext.Set<Entity>().Find(id);
        }

        public Entity GetById(Guid id)
        {
            return _tcontext.Set<Entity>().Find(id);
        }

        public Entity FindFirstOrDefault(Expression<Func<Entity, bool>> match)
        {
            return _tcontext.Set<Entity>().FirstOrDefault(match);
        }

        public void Remove(Entity obj)
        {
            _tcontext.Set(typeof(Entity)).Attach(obj);
            _tcontext.Set<Entity>().Remove(obj);
            _tcontext.SaveChanges();
        }

        public void Remove(IList<Entity> obj)
        {
            foreach (var item in obj)
            {
                _tcontext.Set(typeof(Entity)).Attach(item);
                _tcontext.Entry(item).State = EntityState.Deleted;
            }

            _tcontext.SaveChanges();
        }

        public void Update(Entity obj)
        {
            _tcontext.Set(typeof(Entity)).Attach(obj);
            _tcontext.Entry(obj).State = EntityState.Modified;
            _tcontext.SaveChanges();
        }
        public void Dispose()
        {
            _tcontext.Dispose();
        }
    }
}
