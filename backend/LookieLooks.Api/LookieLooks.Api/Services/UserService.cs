using LookieLooks.Api.Domain;
using LookieLooks.Api.Interfaces;
using LookieLooks.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoRepository<User> _userRepository;
        public UserService(IMongoRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        private string AddUser(string userName)
        {
            User newUser = new User()
            {
                Score = 0,
                Username = userName,
                AvatarImageUrl = ""
            };
            _userRepository.InsertOne(newUser);

            return newUser.Id.ToString();
        }

        public User GetUser(Guid userId)
        {
            return _userRepository.FindById(userId.ToString());
        }

        public string GetUserId(string userName)
        {
            User selectedUser = _userRepository.FindOne(user => user.Username == userName);
            if(selectedUser == null)
            {
                return AddUser(userName);
            } else
            {
                return selectedUser.Id.ToString();
            }
        }
    }
}
