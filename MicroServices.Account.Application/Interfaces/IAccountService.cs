using MicroServices.Account.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Account.Application.Interfaces
{
    public interface IAccountService
    {
        Task<User> Create(User user);
        Task<bool> Delete(User user);
        Task<bool> Update(User user);
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<User>> Filter(Expression<Func<User, bool>> predicate);

    }
}
