using Core.Abstract;
using Core.Data;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace DAL.Infrastructure
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private DbContext _context;
        private readonly IDbFactory _factory;
        private Hashtable _repositories;

        public UnitOfWork(IDbFactory dbFactory)
        {
            if (dbFactory == null)
            {
                throw new ArgumentNullException("dbFactory");
            }

            _factory = dbFactory;
            _repositories = new Hashtable();
        }

        public DbContext DbContext
        {
            get { return _context ?? (_context = _factory.Init()); }
        }

        public virtual IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            var type = typeof(TEntity);
            var key = type.Name;
            if (_repositories.ContainsKey(key))
            {
                return (IRepository<TEntity>)_repositories[key];
            }

            var repositoryType = typeof(Repository<>);
            _repositories.Add(key, Activator.CreateInstance(repositoryType.MakeGenericType(type), DbContext));

            return (IRepository<TEntity>)_repositories[key];
        }

        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        protected override void DisposeCore()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
