using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAngular.Auth.api.Models;

namespace TaskAngular.Auth.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private List<Account> Accounts => new List<Account>
        {
            new Account()
            {
                Id = Guid.Parse("b168d863-9427-4430-a3ca-2b224ad6767a"),
                Email = "user@email.com",
                Password = "user",
                Roles = new Role[] {Role.User}
            },
            new Account()
            {
                Id = Guid.Parse("7b68ds63-9427-4430-b3ca-2b224ad6767a"),
                Email = "user2@email.com",
                Password = "user2",
                Roles = new Role[] {Role.User}
            },
            new Account()
            {
                Id = Guid.Parse("7b68ds63-b3ca-9427-9427-2b224ad6767a"),
                Email = "admin@email.com",
                Password = "admin",
                Roles = new Role[] {Role.Admin}
            },
        };

        [Route("login")]
        [HttpPost]

        public IActionResult Login()
        {

        }
    }
}
