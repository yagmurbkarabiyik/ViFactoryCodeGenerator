using Microsoft.EntityFrameworkCore;
using Tea.Core.Models;
using Tea.Core.Models.RepositoryModels;
using Tea.Core.RepositoryModels;
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

        public void Delete(RepositoryDeleteRequest<T> request)
        {
            _dbSet.Remove(request.Model);
        }

        public async Task<T?> FindAsync<TKey>(RepositoryFindRequest<TKey> request)
        {
            return await _dbSet.FindAsync(request.Key);
        }

        public async Task<T?> GetAsync(RepositoryGetRequest<T> request)
        {
            var db = _dbSet.AsQueryable<T>();

            if (request.Include != null)
                db = request.Include(db);

            if (request.AsNoTracking)
                db = db.AsNoTracking();

            if (request.IsLast)
                return await db.OrderByDescending(x => x.Id).FirstOrDefaultAsync(request.Filter);

            return await db.FirstOrDefaultAsync(request.Filter);
        }

        public async Task<TResult?> GetAsync<TResult>(RepositoryGetAsTResultRequest<T, TResult> request) where TResult : class
        {
            if (request.IsLast)
                return await _dbSet.Where(request.Filter).OrderByDescending(x => x.Id).Select(request.Projection).FirstOrDefaultAsync();

            return await _dbSet.Where(request.Filter).Select(request.Projection).FirstOrDefaultAsync();
        }

        public IQueryable<T> List(RepositoryListRequest<T> request)
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

            if (request.AsNoTracking)
                db = db.AsNoTracking();

            return db;
        }

        public IQueryable<TResult> List<TResult>(RepositoryListAsTResultRequest<T, TResult> request) where TResult : class
        {
            var db = _dbSet.AsQueryable<T>();

            if (request.Filter != null)
                db = db.Where(request.Filter);

            if (request.OrderBy != null)
                db = request.OrderBy(db);

            db = db.Skip(request.Skip);

            if (request.Take > 0)
                db = db.Take(request.Take);

            return db.Select(request.Projection);
        }

        public async Task<PaginationResponse<T>> PaginationAsync(RepositoryPaginationRequest<T> request)
        {
            var db = List(new RepositoryListRequest<T>
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
            var db = List(new RepositoryListAsTResultRequest<T, TResult>
            {
                Projection = request.Projection,
                Filter = request.Filter,
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

        public async Task<bool> AnyAsync(RepositoryAnyRequest<T> request)
        {
            return await _dbSet.AnyAsync(request.Filter);
        }

        public void CreateBulk(RepositoryCreateBulkRequest<T> request)
        {
            _dbSet.AddRange(request.Model);
        }

        public void UpdateBulk(RepositoryUpdateBulkRequest<T> request)
        {
            _dbSet.UpdateRange(request.Model);
        }
    }
}