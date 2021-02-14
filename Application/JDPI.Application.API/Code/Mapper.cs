using JDPI.Application.API.Models;
using JDPI.Platform.Entity.DTOs;

namespace JDPI.Application.API.Code
{
    public static class Mapper
    {
        public static SaveNewUserDTO SaveNewUserModelToDTO(UserRequest model)
        {
            SaveNewUserDTO saveNewUserDTO = new SaveNewUserDTO
            {
                UserName = model.UserName,
                Password = model.Password
            };

            return saveNewUserDTO;
        }
    }
}