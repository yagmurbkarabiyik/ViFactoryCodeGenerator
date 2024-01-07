using System.Linq.Expressions;
using Milk.Core.Models;
using Milk.Domain.IdentityModels;

namespace Milk.Dal.Data.IDalRepos
{
    public interface IAppUserRepository
    {
        void Update(AppUser model);
        Task<AppUser?> GetAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking, params string[] tables);
        IQueryable<AppUser> GetListAsync(Expression<Func<AppUser, bool>>? filter = null, bool asNoTracking = true, string orderBy = "Id", bool isDesc = false, int skip = 0, int take = 10, params string[] tables);
        Task<PaginationResponse<AppUser>> GetPaginationAsync(Expression<Func<AppUser, bool>>? filter = null, string orderBy = "Id", bool isDesc = false, int page = 1, int take = 10, params string[] tables);
        Task<TResult?> GetAsync<TResult>(Expression<Func<AppUser, TResult>> projection, Expression<Func<AppUser, bool>> filter);
        IQueryable<TResult> GetListAsync<TResult>(Expression<Func<AppUser, TResult>> projection, Expression<Func<AppUser, bool>>? filter = null, string orderBy = "Id", bool isDesc = false, int skip = 0, int take = 10);
        Task<PaginationResponse<TResult>> GetPaginationAsync<TResult>(Expression<Func<AppUser, TResult>> projection, Expression<Func<AppUser, bool>>? filter = null, string orderBy = "Id", bool isDesc = false, int page = 1, int take = 10);
    }
}
