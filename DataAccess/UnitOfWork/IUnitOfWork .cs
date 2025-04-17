using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {

        public IRepository<T> GetDynamicRepository<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        Task SaveChangesAsync();
        void SaveChanges();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        public void AttachEntity<T>(T entity) where T : class;
    }
}
