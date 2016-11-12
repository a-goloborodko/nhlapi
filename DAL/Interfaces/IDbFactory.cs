using DAL.Infrastructure;
using System;

namespace DAL.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        EfContext Init();
    }
}
