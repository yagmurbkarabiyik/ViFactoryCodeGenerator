using Coffee.Core.Models;
using Coffee.Core.Services;
using Coffee.Dal.Context;

namespace Coffee.Dal.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly  CoffeeDbContext _ctx;
        public UnitOfWork(CoffeeDbContext ctx)
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