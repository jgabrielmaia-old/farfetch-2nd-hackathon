using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Interfaces
{
    public interface IUserService
    {
        public Domain.User GetUser(string userId);
        public string GetUserId(string userName);
    }
}
