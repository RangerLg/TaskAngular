using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskAngular.Auth.api.Models;
using TaskAngular.Auth.Common;
using TaskAngular.Auth.api.DbContextApp;
using System.Net;

namespace TaskAngular.Auth.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<AuthOptions> AuthOptions;
        private readonly ApplicationDbContext _applicationDbContext;
        public AuthController(IOptions<AuthOptions> authOptions, ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            AuthOptions = authOptions;

        }           
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody]LoginAndRegister request)
        {
            var user = AuthenticateUser(request.Email, request.Password);
            if (user != null)
            {
                var token = GenerateJWT(user);
                return Ok(new {access_token= token });
            }
            return Unauthorized();

        }
        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] LoginAndRegister request)
        {
            try
            {
                _applicationDbContext.Accounts.Add(new Account { Id = Guid.NewGuid(), Email = request.Email, Password = request.Password, Roles = "User" });
                _applicationDbContext.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        private string GenerateJWT(Account user)
        {
            var authParams = AuthOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString())
            };
            foreach(var role in user.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private Account AuthenticateUser(string email, string password)
        {
            return _applicationDbContext.Accounts.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
