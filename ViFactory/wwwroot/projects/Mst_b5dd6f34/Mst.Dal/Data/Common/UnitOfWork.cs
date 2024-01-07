using Mst.Core.Models;
using Mst.Core.Services;
using Mst.Dal.Context;

namespace Mst.Dal.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly  MstDbContext _ctx;
        public UnitOfWork(MstDbContext ctx)
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