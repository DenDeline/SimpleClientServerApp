using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SS.Persistence
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
