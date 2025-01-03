using System.Collections.Generic;

namespace ProductInventorySystem
{
    public class DbContext
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<Product> Products { get; set; }
        }
    }
}
