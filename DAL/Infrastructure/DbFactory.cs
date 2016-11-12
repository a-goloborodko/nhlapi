using Core.Abstract;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private EfContext _context;

        public EfContext Init()
        {
            return _context ?? (_context = new EfContext());
        }

        protected override void DisposeCore()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
