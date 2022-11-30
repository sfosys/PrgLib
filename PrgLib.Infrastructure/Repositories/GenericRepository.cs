using Microsoft.EntityFrameworkCore;
using PrgLib.Core.Interfaces;
using PrgLib.Infrastructure.Data;
using System.Linq.Expressions;

namespace PrgLib.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AppDbContext appDbContext;
        private readonly DbSet<T> entity;

        public GenericRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            entity = appDbContext.Set<T>();

        }
        public async Task<IList<T>>? GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = entity;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T>? Get(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> query = entity;
            if (includes != null)
            {
                foreach (var include in includes) 
                    query = query.Include(include);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task Insert(T newRecord)
        {
            await entity.AddAsync(newRecord);
        }

        public async Task InsertRange(IEnumerable<T> newRecords)
        {
            await entity.AddRangeAsync(newRecords);
        }

        public async Task Delete(int id)
        {
            var rec = await entity.FindAsync();
            entity.Remove(rec);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            entity.RemoveRange(entities);
        }

        public void Update(T updatedRecord)
        {
            entity.Attach(updatedRecord);
            appDbContext.Entry(entity).State = EntityState.Modified;

        }
    }
}
