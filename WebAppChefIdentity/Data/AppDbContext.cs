using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppChefIdentity.Models;

namespace WebAppChefIdentity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppChefIdentity.Models.Profile> Profile { get; set; }

        public DbSet<WebAppChefIdentity.Models.Post> Post { get; set; }

        public DbSet<WebAppChefIdentity.Models.Receita> Receita { get; set; }
    }
}
