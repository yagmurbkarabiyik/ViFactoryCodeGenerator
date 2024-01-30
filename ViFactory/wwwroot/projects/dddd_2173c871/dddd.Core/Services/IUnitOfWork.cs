using dddd.Core.Models;

namespace dddd.Core.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UnitOfWorkResponse SaveChanges();
        public Task<UnitOfWorkResponse> SaveChangesAsync();
    }
}


