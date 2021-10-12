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

namespace TaskAngular.Auth.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<AuthOptions> AuthOptions;
        public AuthController(IOptions<AuthOptions> authOptions )
        {
            AuthOptions = authOptions;
        }

        

        private List<Account> Accounts => new List<Account>
        {
            new Account()
            {
                Id = Guid.Parse("65fe2aac-88dd-4236-9f3e-ee81de8c2430"),
                Email = "user@email.com",
                Password = "user",
                Roles = new Role[] {Role.User}
            },
            new Account()
            {
                Email = "user2@email.com",
                Password = "user2",
                Roles = new Role[] {Role.User}
            },
            new Account()
            {
                Email = "admin@email.com",
                Password = "admin",
                Roles = new Role[] {Role.Admin}
            },
        };

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody]Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);

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
        private Account AuthenticateUser(string email,string password)
        {
            return Accounts.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
