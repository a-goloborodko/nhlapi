using Core.Models;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
