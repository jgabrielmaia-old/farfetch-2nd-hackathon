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
                UserName = userName,
                AvatarImageUrl = ""
            };
            _userRepository.InsertOne(newUser);

            return userName;
        }

        public User GetUser(string userId)
        {
            return _userRepository.FindById(userId);
        }

        public string GetUserId(string userName)
        {
            User selectedUser = _userRepository.FindOne(user => user.UserName == userName);
            if(selectedUser == null)
            {
                return AddUser(userName);
            } else
            {
                return selectedUser.UserName;
            }
        }

        public List<Model.User> getTopUsers()
        {
            int numberOfUsers = _userRepository.FilterBy(x => true).Count();
            if(numberOfUsers > 10)
            {
                return _userRepository.FilterBy(x => true).OrderByDescending(user => user.Score).Take(10).Select(user=>user.GetUserDTO()).ToList();
            } else
            {
                return _userRepository.FilterBy(x => true).OrderByDescending(user => user.Score).Select(user => user.GetUserDTO()).ToList();
            }
        }
    }
}
