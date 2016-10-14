using Core.Abstract;
using Core.Data;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class Repository<TEntity> : Disposable, IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        //TODO: add GetAllIncluding
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public virtual void Add(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Added;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
                _dbSet.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity != null)
                _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int entityId)
        {
            TEntity entity = default(TEntity);
            entity.Id = entityId;

            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity != null)
                _context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> entities = _dbSet.Where(where).AsEnumerable();
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        protected override void DisposeCore()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
