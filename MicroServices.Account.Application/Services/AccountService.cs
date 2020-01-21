using MicroService.Core.Bus;
using MicroServices.Account.Application.Interfaces;
using MicroServices.Account.Domain.Interfaces;
using MicroServices.Account.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Account.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public async Task<User> Create(User user)
        {
            return await _accountRepository.Create(user);
        }

        public async Task<bool> Delete(User user)
        {
            return await _accountRepository.Delete(user);
        }

        public async Task<IEnumerable<User>> Filter(Expression<Func<User, bool>> predicate)
        {
            return await _accountRepository.Get(predicate);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _accountRepository.Get();
        }

        public async Task<User> GetById(int id)
        {
            return await _accountRepository.Get(id);
        }

        public async Task<bool> Update(User user)
        {
            return await _accountRepository.Update(user);
        }
    }
}
