using Example.Shared.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.Shared.DomainServices
{
    public class BaseService<Entity, TContext> : IBaseService<Entity, TContext> where Entity : class where TContext : DbContext
    {
        public readonly IBaseRepository<Entity, TContext> _baseRepository;

        public BaseService(IBaseRepository<Entity, TContext> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual void Add(Entity obj)
        {
            _baseRepository.Add(obj);
        }

        public virtual void Add(IList<Entity> obj)
        {
            _baseRepository.Add(obj);
        }

        public Entity FindFirstOrDefault(Expression<Func<Entity, bool>> match)
        {
            return _baseRepository.FindFirstOrDefault(match);
        }

        public IQueryable<Entity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public IQueryable<Entity> GetAll(Expression<Func<Entity, bool>> match)
        {
            return _baseRepository.GetAll(match);
        }

        public Entity GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public Entity GetById(Guid id)
        {
            return _baseRepository.GetById(id);
        }

        public virtual void Delete(Entity obj)
        {
            _baseRepository.Remove(obj);
        }

        public virtual void Delete(IList<Entity> obj)
        {
            _baseRepository.Remove(obj);
        }

        public virtual void Update(Entity obj)
        {
            try
            {
                _baseRepository.Update(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("Error to update", ex);
            }
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
