using Neew.Core.Models;

namespace Neew.Core.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UnitOfWorkResponse SaveChanges();
        public Task<UnitOfWorkResponse> SaveChangesAsync();
    }
}


