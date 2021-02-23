using JDPI.Application.API.Models;
using JDPI.Common.Util.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDPI.Application.API.Controllers
{
    public class ConnectController : Controller
    {
        private IConfiguration _config;

        public ConnectController(IConfiguration configuration)
        {
            _config = configuration;
        }

        //public JsonResult Token([FromBody] TokenRequest tokenRequest)
        //{
        //    return new JsonResult(GerarTokenJWT(tokenRequest));
        //}

        //private Token GerarTokenJWT(TokenRequest tokenRequest)
        //{
        //    var issuer = _config["Jwt:Issuer"];
        //    var audience = _config["Jwt:Audience"];
        //    var securityKey = new SymetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(issuer, audience, expire: DateTime.Now.AddMinutes(30), signingCredentials: credentials);

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var stringToken = tokenHandler.WriteToken(token);

        //    Token tokenJwt = new Token()
        //    {
        //        access_token = stringToken,
        //        expires_in = token.Payload.Exp.Value,
        //        token_type = "Bearer",
        //        scope = tokenRequest.scope
        //    };
        //    return tokenJwt;

        }
    }
}
