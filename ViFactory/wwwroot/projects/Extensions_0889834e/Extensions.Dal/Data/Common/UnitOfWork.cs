using Extensions.Core.Models;
using Extensions.Core.Services;
using Extensions.Dal.Context;

namespace Extensions.Dal.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly  ExtensionsDbContext _ctx;
        public UnitOfWork(ExtensionsDbContext ctx)
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