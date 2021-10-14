using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public string Email { get; set; }
        public Guid Id { get; set; }
        
        public string Password { get; set; }

        public string Roles { get; set; }     
    }
    
}
