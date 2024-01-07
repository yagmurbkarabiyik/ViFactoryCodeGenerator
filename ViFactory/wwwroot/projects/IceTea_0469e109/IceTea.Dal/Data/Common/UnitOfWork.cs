using IceTea.Core.Models;
using IceTea.Core.Services;
using IceTea.Dal.Context;

namespace IceTea.Dal.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly  IceTeaDbContext _ctx;
        public UnitOfWork(IceTeaDbContext ctx)
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