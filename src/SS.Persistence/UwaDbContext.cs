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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UwaDbContext).Assembly);
        }
    }
}
