using System.Linq.Expressions;
using Ybk.Core.Models;
using Ybk.Domain.IdentityModels;

namespace Ybk.Dal.Data.IDalRepos
{
    public interface IAppUserRepository
    {
        Task<AppUser?> GetAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking, params string[] tables);
        IQueryable<AppUser> GetListAsync(Expression<Func<AppUser, bool>>? filter = null, bool asNoTracking = true, string orderBy = "Id", bool isDesc = false, int skip = 0, int take = 10, params string[] tables);
        Task<PaginationResponse<AppUser>> GetPaginationAsync(Expression<Func<AppUser, bool>>? filter = null, string orderBy = "Id", bool isDesc = false, int page = 1, int take = 10, params string[] tables);
        Task<TResult?> GetAsync<TResult>(Expression<Func<AppUser, TResult>> projection, Expression<Func<AppUser, bool>> filter);
        IQueryable<TResult> GetListAsync<TResult>(Expression<Func<AppUser, TResult>> projection, Expression<Func<AppUser, bool>>? filter = null, string orderBy = "Id", bool isDesc = false, int skip = 0, int take = 10);
        Task<PaginationResponse<TResult>> GetPaginationAsync<TResult>(Expression<Func<AppUser, TResult>> projection, Expression<Func<AppUser, bool>>? filter = null, string orderBy = "Id", bool isDesc = false, int page = 1, int take = 10);
    }
}
