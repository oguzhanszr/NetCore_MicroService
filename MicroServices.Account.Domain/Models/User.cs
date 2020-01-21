using MicroService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServices.Account.Domain.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
