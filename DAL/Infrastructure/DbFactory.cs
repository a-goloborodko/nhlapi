using Core.Abstract;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DbContext _context;

        public DbContext Init()
        {
            return _context ?? (_context = new DbContext());
        }

        protected override void DisposeCore()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
