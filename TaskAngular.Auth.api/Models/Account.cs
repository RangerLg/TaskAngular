using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAngular.Auth.api.Models
{
    public enum Role
    {
        User,
        Admin
    }
    public class Account
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public Role[] Roles { get; set; }     
    }
    
}
