using DAL.Infrastructure;
using DAL.Repositories;
using System;

namespace DAL.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        DbContext Init();
    }
}
