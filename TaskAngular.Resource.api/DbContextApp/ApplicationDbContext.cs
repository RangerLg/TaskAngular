using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAngular.Resource.api.Models;

namespace TaskAngular.Resource.api.DbContextApp
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<Collection> Collections { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

       
       
    }
}
