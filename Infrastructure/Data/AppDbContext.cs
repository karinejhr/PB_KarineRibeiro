using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace WebAppChefIdentity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profile { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Receita> Receita { get; set; }
    }
}
