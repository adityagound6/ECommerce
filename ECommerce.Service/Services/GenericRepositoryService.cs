using ECommerce.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Service.Services
{
    public abstract class GenericRepositoryService<C, T> : IGenericRepository<T> where T : class where C : DbContext, new()
    {
        protected C dbContext = new C();
        public virtual IQueryable<T> GetAllQuerable()
        {
            return dbContext.Set<T>().AsNoTracking();
        }
        public async virtual Task<List<T>> GetAll()
        {
            List<T> query = await dbContext.Set<T>().ToListAsync();
            return query;
        }
        public async virtual Task<T> GetById(int Id)
        {
            return await dbContext.Set<T>().FindAsync(Id);
        }
        public async Task<List<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            List<T> query = await dbContext.Set<T>().Where(predicate).ToListAsync();
            return query;
        }
        public async Task<T> FirstOrDefaultAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var res = await dbContext.Set<T>().FirstOrDefaultAsync(predicate);
            return res;
        }
        public T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var res = dbContext.Set<T>().FirstOrDefault(predicate);
            return res;
        }

        public async Task<bool> AnyAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var res = await dbContext.Set<T>().AnyAsync(predicate);
            return res;
        }

        public bool Any(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var res = dbContext.Set<T>().Any(predicate);
            return res;
        }

        public async virtual Task<T> Add(T entity)
        {
            try
            {
                dbContext.Set<T>().Add(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return entity;
        }

        public async virtual Task Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
            return;
        }

        public async virtual Task Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return;
        }

        public async virtual Task Save()
        {
            await dbContext.SaveChangesAsync();
            return;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
