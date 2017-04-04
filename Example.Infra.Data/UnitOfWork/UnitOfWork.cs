using Example.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyContext _context;

        public UnitOfWork(MyContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public void RoolBack()
        {
            _context.Database.CurrentTransaction.Rollback();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }
    }
}
