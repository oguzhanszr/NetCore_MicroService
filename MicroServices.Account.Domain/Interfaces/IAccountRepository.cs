using MicroService.Core.Interfaces;
using MicroServices.Account.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.Account.Domain.Interfaces
{
    public interface IAccountRepository : IRepository<User>
    {
    }
}
