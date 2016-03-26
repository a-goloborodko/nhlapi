using Core.Data;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        //TODO: изменить EFDbContext на custom интерфейс IContext
        private readonly EFDbContext _context;
        private readonly IDbSet<TEntity> _dbSet;
        private bool _disposed;

        public Repository(EFDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        //TODO: add GetAllIncluding
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Insert(TEntity entity)
        {
            _context.SetAsAdded(entity);
        }

        public void Update(TEntity entity)
        {
            _context.SetAsModified(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.SetAsDeleted(entity);
        }

        public TEntity FindById(int entityId)
        {
            return _dbSet.FirstOrDefault(x => x.Id == entityId);
        }

        //TODO: вынести в context в транзакции
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
