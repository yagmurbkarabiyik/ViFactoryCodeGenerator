using Artyfy.Core.Models;
using Artyfy.Core.Services;
using Artyfy.Dal.Context;

namespace Artyfy.Dal.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly  ArtyfyDbContext _ctx;
        public UnitOfWork(ArtyfyDbContext ctx)
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