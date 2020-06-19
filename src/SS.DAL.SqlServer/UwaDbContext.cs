using Microsoft.EntityFrameworkCore;
using SS.Application.Common.Interfaces;
using SS.Domain.Entities;

namespace SS.DAL.SqlServer
{
    public class UwaDbContext: DbContext, IUwaDbContext
    {
        public UwaDbContext(DbContextOptions<UwaDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UwaDbContext).Assembly);
        }
    }
}
