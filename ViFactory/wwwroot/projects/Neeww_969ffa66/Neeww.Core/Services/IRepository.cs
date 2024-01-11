using Neeww.Core.Models;
using Neeww.Core.Models.RepositoryModels;
using Neeww.Core.RepositoryModels;
using Neeww.Core.Models;
using Neeww.Core.Models.RepositoryModels;
using Neeww.Core.RepositoryModels;

namespace Neeww.Core.Services
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        void Create(RepositoryCreateRequest<T> request);
        void CreateBulk(RepositoryCreateBulkRequest<T> request);
        void Update(RepositoryUpdateRequest<T> request);
        void UpdateBulk(RepositoryUpdateBulkRequest<T> request);
        void Delete(RepositoryDeleteRequest<T> request);
        Task<T?> FindAsync<TKey>(RepositoryFindRequest<TKey> request);
        Task<bool> AnyAsync(RepositoryAnyRequest<T> request);
        Task<T?> GetAsync(RepositoryGetRequest<T> request);
        Task<TResult?> GetAsync<TResult>(RepositoryGetAsTResultRequest<T, TResult> request) where TResult : class;
        IQueryable<T> List(RepositoryListRequest<T> request);
        IQueryable<TResult> List<TResult>(RepositoryListAsTResultRequest<T, TResult> request) where TResult : class;
        Task<PaginationResponse<T>> PaginationAsync(RepositoryPaginationRequest<T> request);
        Task<PaginationResponse<TResult>> PaginationAsync<TResult>(RepositoryPaginationAsTResultRequest<T, TResult> request) where TResult : class;
    }
}


