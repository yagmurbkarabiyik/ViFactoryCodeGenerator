using Deneme.Core.Models;
using Deneme.Core.Services;
using Deneme.Dal.Context;

namespace Deneme.Dal.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly  DenemeDbContext _ctx;
        public UnitOfWork(DenemeDbContext ctx)
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