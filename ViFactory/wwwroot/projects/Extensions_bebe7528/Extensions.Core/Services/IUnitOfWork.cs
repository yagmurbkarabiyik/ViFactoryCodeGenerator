using Extensions.Core.Models;

namespace Extensions.Core.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UnitOfWorkResponse SaveChanges();
        public Task<UnitOfWorkResponse> SaveChangesAsync();
    }
}


