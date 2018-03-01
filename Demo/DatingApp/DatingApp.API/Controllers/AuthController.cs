using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data.Repositories.Authentication;
using DatingApp.API.DTO;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthRepository _authRepository, IConfiguration _configuration)
        {
            this._configuration = _configuration;
            this._authRepository = _authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterUser user)
        {
            user.UserName = user.UserName.ToLower();
            if (await _authRepository.UserExists(user.UserName))
                ModelState.AddModelError("UserName", "UserName already exists");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userToCreate = new User { UserName = user.UserName };
            var createdUser = await _authRepository.Register(userToCreate, user.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginUser user)
        {
            throw new Exception("Some funny exception");
            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                user.UserName = user.UserName.ToLower();
            }

            var userFromRepo = await _authRepository.Login(user.UserName, user.Password);
            if (userFromRepo == null)
                return Unauthorized();

            /// generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyString = _configuration.GetSection("AppSettings:Token").Value;
            var key = Encoding.ASCII.GetBytes(keyString);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.ID.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.UserName)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new { tokenString });
        }
    }
}