using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class UwaDbContext: DbContext, IUwaDbContext
    {
        public UwaDbContext(DbContextOptions<UwaDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entity in ChangeTracker.Entries<Post>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entity.Entity.LastModified = DateTime.UtcNow;
                        break;;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UwaDbContext).Assembly);
        }
    }
}
