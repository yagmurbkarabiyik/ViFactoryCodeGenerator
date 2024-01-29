using SampleProject.Core.Models;

namespace SampleProject.Core.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UnitOfWorkResponse SaveChanges();
        public Task<UnitOfWorkResponse> SaveChangesAsync();
    }
}


