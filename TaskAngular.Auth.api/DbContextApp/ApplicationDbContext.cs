using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAngular.Auth.api.Models;

namespace TaskAngular.Auth.api.DbContextApp
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AngularAccounts;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
       
    }
}
