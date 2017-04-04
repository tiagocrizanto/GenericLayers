using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infra.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void RoolBack();
        void Save();
        void Dispose();
    }
}
