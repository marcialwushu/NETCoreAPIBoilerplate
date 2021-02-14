using System;
using System.Collections.Generic;
using JDPI.Application.API.Code;
using JDPI.Application.API.Models;
using JDPI.Platform.Entity.DTOs;
using JDPI.Platform.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JDPI.Application.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Criar Usuario
        /// </summary>
        /// <returns>Cria usuário na base de dados</returns>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        [HttpPost]
        [Route("v1/incluir")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public UserResponse SaveUser([FromBody] UserRequest model)
        {
            try
            {
                SaveNewUserDTO saveNewUserDTO = Mapper.SaveNewUserModelToDTO(model);

                _userService.SaveNewUser(saveNewUserDTO);

                return new UserResponse(new { Success = true });
            }
            catch (Exception ex)
            {
                
                return new UserResponse(new { Success = false, Error = ex.Message });
            }
        }
    }
}