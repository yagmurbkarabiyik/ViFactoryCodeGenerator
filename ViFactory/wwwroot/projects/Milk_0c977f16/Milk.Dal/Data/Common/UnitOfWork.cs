using Milk.Core.Models;
using Milk.Core.Services;
using Milk.Dal.Context;

namespace Milk.Dal.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly  MilkDbContext _ctx;
        public UnitOfWork(MilkDbContext ctx)
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