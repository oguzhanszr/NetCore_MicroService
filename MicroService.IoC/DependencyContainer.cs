using MediatR;
using MicroService.Bus;
using MicroService.Core.Bus;
using MicroServices.Account.Application.Interfaces;
using MicroServices.Account.Application.Services;
using MicroServices.Account.Data.Context;
using MicroServices.Account.Data.Repository;
using MicroServices.Account.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            RegisterForAccount(services);
        }

        private static void RegisterForAccount(IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<AccountDbContext>();
        }
    }
}
