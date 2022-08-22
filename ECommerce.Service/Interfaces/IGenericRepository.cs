using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAllQuerable();
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int Id);
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task Save();
    }
}
