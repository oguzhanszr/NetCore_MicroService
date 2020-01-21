using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> Create(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(T entity);

        Task<T> Get(int id);

        Task<IEnumerable<T>> Get();

        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
    }
}
