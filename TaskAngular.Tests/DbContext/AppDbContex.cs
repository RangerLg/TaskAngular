using Microsoft.EntityFrameworkCore;
using TaskAngular.Resource.api.Models;
using Account = TaskAngular.Auth.api.Models.Account;

namespace TaskAngular.Tests.DbContext
{
    public class AppDbContex:Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AngularAccounts;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

    }
}