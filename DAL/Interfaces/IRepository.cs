using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int entityId);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        TEntity GetById(long id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        void AddRange(IEnumerable<TEntity> entities);
    }
}
