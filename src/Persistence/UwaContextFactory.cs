using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence
{
    public class UwaContextFactory: IDesignTimeDbContextFactory<UwaDbContext>
    {
        public UwaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UwaDbContext>();
            optionsBuilder.UseSqlServer("Data Source=UwaDatabase.db");

            return new UwaDbContext(optionsBuilder.Options);
        }
    }
}
