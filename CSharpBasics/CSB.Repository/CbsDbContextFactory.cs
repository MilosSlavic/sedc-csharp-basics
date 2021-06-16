using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CSB.Repository
{
    public class CbsDbContextFactory : IDesignTimeDbContextFactory<CbsDbContext>
    {
        public CbsDbContext CreateDbContext(string[] args)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<CbsDbContext>();
            dbContextOptionsBuilder.UseSqlite("Data Source=file.db");
            return new CbsDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
