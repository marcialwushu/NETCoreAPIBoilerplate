using JDPI.Platform.Entity;
using JDPI.Platform.Entity.DTOs;

namespace JDPI.Platform.Service.Interfaces
{
    public interface IUserService
    {
         void SaveNewUser(SaveNewUserDTO newUserDTO);
    }
}