using System.Collections.Generic;
using JDPI.Application.API.Models;
using JDPI.Application.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JDPI.Application.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Listar Usuario
        /// </summary>
        /// <returns>Lista todos os usuarios</returns>
        /// <response code="200">Retorna a lista de Todos ou o Todo com o id especificado</response>
        /// <response code="404">Se não há Todo com o id especificado</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Usuario>> Listar() => 
            _userService.listar();
    }
}