using MicroServices.Account.Data.Context;
using MicroServices.Account.Domain.Interfaces;
using MicroServices.Account.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Account.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext _context;

        public AccountRepository(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User entity)
        {
            if (entity != null)
            {
                await _context.Users.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<bool> Delete(User entity)
        {
            int status = 0;
            if(entity != null)
            {
                _context.Users.Remove(entity);
                status = await _context.SaveChangesAsync();
            }
            return status > 0 ? true : false;
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);

        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> Get(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.Where(predicate).ToListAsync();
        }

        public async Task<bool> Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            int status = await _context.SaveChangesAsync();

            return status > 0 ? true : false;
        }
    }
}
