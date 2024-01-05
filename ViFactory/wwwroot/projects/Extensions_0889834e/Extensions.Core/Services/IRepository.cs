using System.Linq.Expressions;
using Extensions.Core.Models;
using Extensions.Core.Models.RepositoryModels;
using Extensions.Core.RepositoryModels;
namespace Extensions.Core.Services
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        void Create(RepositoryCreateRequest<T> request);
        void Update(RepositoryUpdateRequest<T> request);
        void SoftDelete(RepositorySoftDeleteRequest<T> request);
        void Delete(RepositoryDeleteRequest<T> request);
        Task<bool> IsExist(RepositoryIsExistRequest<T> request);
        Task<T?> GetAsync(RepositoryGetRequest<T> request);
        IQueryable<T> ListAsync(RepositoryListRequest<T> request);
        Task<PaginationResponse<T>> GetPaginationAsync(RepositoryPaginationRequest<T> request);
        Task<TResult?> GetAsync<TResult>(RepositoryGetAsTResultRequest<T, TResult> request) where TResult : class;
        IQueryable<TResult> ListAsync<TResult>(RepositoryListAsTResultRequest<T, TResult> request) where TResult : class;
        Task<PaginationResponse<TResult>> PaginationAsync<TResult>(RepositoryPaginationAsTResultRequest<T, TResult> request) where TResult : class;
    }
}


