using System;
using JDPI.Platform.Business.Interfaces;
using JDPI.Platform.Entity;
using JDPI.Platform.Entity.DTOs;
using JDPI.Platform.Service.Interfaces;

namespace JDPI.Platform.Service
{
    public class UserService : IUserService
    {
        public IUserBUS<User> _userBUS;

        public UserService(IUserBUS<User> userBUS)
        {
            _userBUS = userBUS;
        }

        public void SaveNewUser(SaveNewUserDTO newUserDTO){
            User newUser = new User
            {
                UserName = newUserDTO.UserName,
                Password = newUserDTO.Password, 
            };

            _userBUS.Save(newUser);
        }

    }
}