using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tea.Core.Models;
using Tea.Dal.Context;
using Tea.Dal.Data.IDalRepos;
using Tea.Domain.IdentityModels;

namespace Tea.Dal.Data.DalRepos
{
     public class AppUserRepository : IAppUserRepository
    {
        protected readonly TeaDbContext _dbContext;
        private readonly DbSet<AppUser> _dbSet;

        public AppUserRepository(TeaDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<AppUser>();
        }

        public async Task<AppUser?> GetAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking, params string[] tables)
        {
            var db = _dbSet.AsQueryable<AppUser>();

            if (tables != null && tables.Length > 0)
                db = IncludeTables(db, tables);

            return asNoTracking
                ? await db.Where(filter).AsNoTracking().FirstOrDefaultAsync()
                : await db.FirstOrDefaultAsync(filter);
        }

        public async Task<TResult?> GetAsync<TResult>(Expression<Func<AppUser, TResult>> projection, Expression<Func<AppUser, bool>> filter)
        {
            return await _dbSet.Where(filter).AsNoTracking().Select(projection).FirstOrDefaultAsync();
        }

        public IQueryable<AppUser> GetListAsync(Expression<Func<AppUser, bool>>? filter = null, bool asNoTracking = true, string orderBy = "Id", bool isDesc = false, int skip = 0, int take = 10, params string[] tables)
        {
            var db = _dbSet.AsQueryable<AppUser>();

            if (tables != null && tables.Length > 0)
                db = IncludeTables(db, tables);

            if (filter != null)
                db = db.Where(filter);

            if (isDesc)
                db = db.OrderByDescending(GetOrderLambda(orderBy));
            else
                db = db.OrderBy(GetOrderLambda(orderBy));

            db = db.Skip(skip);

            if (take > 0)
                db = db.Take(take);

            return asNoTracking ? db.AsNoTracking() : db;
        }

        public IQueryable<TResult> GetListAsync<TResult>(Expression<Func<AppUser, TResult>> projection, Expression<Func<AppUser, bool>>? filter = null, string orderBy = "Id", bool isDesc = false, int skip = 0, int take = 10)
        {
            var db = _dbSet.AsQueryable<AppUser>();

            if (filter != null)
                db = db.Where(filter);

            if (isDesc)
                db = db.OrderByDescending(GetOrderLambda(orderBy));
            else
                db = db.OrderBy(GetOrderLambda(orderBy));

            db = db.Skip(skip);

            if (take > 0)
                db = db.Take(take);

            return db.AsNoTracking().Select(projection);
        }

        public async Task<PaginationResponse<AppUser>> GetPaginationAsync(Expression<Func<AppUser, bool>>? filter = null, string orderBy = "Id", bool isDesc = false, int page = 1, int size = 10, params string[] tables)
        {
            var db = GetListAsync(filter, false, orderBy, isDesc, (page - 1) * size, size, tables);

            return new PaginationResponse<AppUser>
            {
                Items = db,
                Page = page,
                Size = size,
                Total = await db.LongCountAsync(),
            };
        }

        public async Task<PaginationResponse<TResult>> GetPaginationAsync<TResult>(Expression<Func<AppUser, TResult>> projection, Expression<Func<AppUser, bool>>? filter = null, string orderBy = "Id", bool isDesc = false, int page = 1, int size = 10)
        {
            var db = GetListAsync(projection, filter, orderBy, isDesc, (page - 1) * size, size);

            return new PaginationResponse<TResult>
            {
                Items = db,
                Page = page,
                Size = size,
                Total = await db.LongCountAsync(),
            };
        }

        private IQueryable<AppUser> IncludeTables(IQueryable<AppUser> db, params string[] tables)
        {
            foreach (var table in tables)
                db = db.Include(table);

            return db;
        }

        private Expression<Func<AppUser, object>> GetOrderLambda(string orderBy)
        {
            var parameter = Expression.Parameter(typeof(AppUser));

            var property = Expression.Property(parameter, orderBy);

            var lambda = Expression.Lambda<Func<AppUser, object>>(Expression.Convert(property, typeof(object)), parameter);

            return lambda;
        }
    }

}
