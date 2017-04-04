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
        private readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public void Add(Entity obj)
        {
            try
            {
                _context.Set<Entity>().Add(obj);
                _context.SaveChanges();
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
                _context.Set<Entity>().AddRange(list);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error to add", ex);
            }
        }

        public IQueryable<Entity> GetAll()
        {
            return _context.Set<Entity>();
        }

        public IQueryable<Entity> GetAll(Expression<Func<Entity, bool>> match)
        {
            return _context.Set<Entity>().Where(match);
        }

        public Entity GetById(int id)
        {
            return _context.Set<Entity>().Find(id);
        }

        public Entity GetById(Guid id)
        {
            return _context.Set<Entity>().Find(id);
        }

        public Entity FindFirstOrDefault(Expression<Func<Entity, bool>> match)
        {
            return _context.Set<Entity>().FirstOrDefault(match);
        }

        public void Remove(Entity obj)
        {
            _context.Set(typeof(Entity)).Attach(obj);
            _context.Set<Entity>().Remove(obj);
            _context.SaveChanges();
        }

        public void Remove(IList<Entity> obj)
        {
            foreach (var item in obj)
            {
                _context.Set(typeof(Entity)).Attach(item);
                _context.Entry(item).State = EntityState.Deleted;
            }

            _context.SaveChanges();
        }

        public void Update(Entity obj)
        {
            _context.Set(typeof(Entity)).Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
