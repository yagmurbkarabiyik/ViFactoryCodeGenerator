using Microsoft.EntityFrameworkCore;
using Tea.Core.Enums;
using Tea.Core.Models;
using Tea.Core.Models.RepositoryModels;
using Tea.Core.RepositoryModels;
using Tea.Core.Services;


namespace Tea.Dal.Data.Common
{
    public class Repository<T, TDbContext> : IRepository<T>
        where T : class, IBaseEntity
        where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(TDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public void Create(RepositoryCreateRequest<T> request)
        {
            request.Model.CreatedDate = DateTime.UtcNow;

            _dbSet.Add(request.Model);
        }
        public void Update(RepositoryUpdateRequest<T> request)
        {
            request.Model.UpdatedDate = DateTime.UtcNow;

            _dbSet.Update(request.Model);
        }
        public void SoftDelete(RepositorySoftDeleteRequest<T> request)
        {
            request.Model.Status = DbEntityState.Deleted;

            Update(new RepositoryUpdateRequest<T> { Model = request.Model });
        }
        public void Delete(RepositoryDeleteRequest<T> request)
        {
            _dbSet.Remove(request.Model);
        }
        public async Task<T?> GetAsync(RepositoryGetRequest<T> request)
        {
            var db = _dbSet.AsQueryable<T>();

            if (request.Include != null)
                db = request.Include(db);

            return request.AsNoTracking
                ? await db.Where(request.Filter).AsNoTracking().FirstOrDefaultAsync()
                : await db.FirstOrDefaultAsync(request.Filter);
        }
        public async Task<TResult?> GetAsync<TResult>(RepositoryGetAsTResultRequest<T, TResult> request) where TResult : class
        {
            return await _dbSet.Where(request.Filter).AsNoTracking().Select(request.Projection).FirstOrDefaultAsync();
        }
        public IQueryable<T> ListAsync(RepositoryListRequest<T> request)
        {
            var db = _dbSet.AsQueryable<T>();

            if (request.Filter != null)
                db = db.Where(request.Filter);

            if (request.Include != null)
                db = request.Include(db);

            if (request.OrderBy != null)
                db = request.OrderBy(db);

            db = db.Skip(request.Skip);

            if (request.Take > 0)
                db = db.Take(request.Take);

            return request.AsNoTracking ? db.AsNoTracking() : db;
        }
        public IQueryable<TResult> ListAsync<TResult>(RepositoryListAsTResultRequest<T, TResult> request) where TResult : class
        {
            var db = _dbSet.AsQueryable<T>();

            if (request.Filter != null)
                db = db.Where(request.Filter);

            if (request.OrderBy != null)
                db = request.OrderBy(db);

            db = db.Skip(request.Skip);

            if (request.Take > 0)
                db = db.Take(request.Take);

            return db.AsNoTracking().Select(request.Projection);
        }
        public async Task<PaginationResponse<T>> GetPaginationAsync(RepositoryPaginationRequest<T> request)
        {
            var db = ListAsync(new RepositoryListRequest<T>
            {
                Filter = request.Filter,
                Include = request.Include,
                OrderBy = request.OrderBy,
                AsNoTracking = true,
                Skip = (request.Page - 1) * request.Size,
                Take = request.Size
            });

            return new PaginationResponse<T>
            {
                Items = db,
                Page = request.Page,
                Size = request.Size,
                Total = await db.LongCountAsync(),
            };
        }
        public async Task<PaginationResponse<TResult>> PaginationAsync<TResult>(RepositoryPaginationAsTResultRequest<T, TResult> request) where TResult : class
        {
            var db = ListAsync(new RepositoryListAsTResultRequest<T, TResult>
            {
                Projection = request.Projection,
                Filter = request.Filter,
                AsNoTracking = true,
                OrderBy = request.OrderBy,
                Skip = (request.Page - 1) * request.Size,
                Take = request.Size,
            });

            return new PaginationResponse<TResult>
            {
                Items = db,
                Page = request.Page,
                Size = request.Size,
                Total = await db.LongCountAsync(),
            };
        }
        public async Task<bool> IsExist(RepositoryIsExistRequest<T> request)
        {
            return await _dbSet.Where(request.Filter).CountAsync() > 0;
        }
    }
}