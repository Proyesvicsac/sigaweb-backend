using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SIGA.Common;
using SIGA.DTO;
using SIGA.Logic.Interface;
using SIGA.ServiceApi.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.ServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioLogic _usuarioLogic;
        private readonly AppSettings _appSettings;
        public UsuarioController(IUsuarioLogic usuarioLogic, IOptions<AppSettings> appSettings)
        {
            _usuarioLogic = usuarioLogic;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO usuario)
        {
            var response = await _usuarioLogic.Authenticate(usuario.NombreUsuario, usuario.Password);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                    return NotFound(response);
            }

            return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpGet("refreshtoken")]
        public async Task<IActionResult> RefreshToken(string Token) 
        {
            var stream = Token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            var jwtSecurityToken = handler.ReadJwtToken(Token);
            var user = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;
            var response = await _usuarioLogic.GetUserData(user);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                    return NotFound(response);
            }

            return BadRequest(response);
        }

        private string BuildToken(Response<UsuarioDTO> usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDto.Data.NomUsuario.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
