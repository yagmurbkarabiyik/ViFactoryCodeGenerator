using Neeww.Core.Models;

namespace Neeww.Core.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UnitOfWorkResponse SaveChanges();
        public Task<UnitOfWorkResponse> SaveChangesAsync();
    }
}


