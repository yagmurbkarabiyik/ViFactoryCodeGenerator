using ExtensionsDeneme.Core.Models;
using ExtensionsDeneme.Core.Services;
using ExtensionsDeneme.Dal.Context;

namespace ExtensionsDeneme.Dal.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly  ExtensionsDenemeDbContext _ctx;
        public UnitOfWork(ExtensionsDenemeDbContext ctx)
        {
            _ctx = ctx;
        }
        public UnitOfWorkResponse SaveChanges()
        {
            try
            {
                return new UnitOfWorkResponse(_ctx.SaveChanges());
            }
            catch (Exception ex)
            {
                return new UnitOfWorkResponse(ex);
            }
        }
        public async Task<UnitOfWorkResponse> SaveChangesAsync()
        {
            try
            {
                return new UnitOfWorkResponse(await _ctx.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                return new UnitOfWorkResponse(ex);
            }
        }
        public void Dispose()
        {
            _ctx?.Dispose();
        }
    }
}