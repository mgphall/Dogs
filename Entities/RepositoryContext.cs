namespace Entities
{
    using Entities.Models;
    using Microsoft.EntityFrameworkCore;

    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
           : base(options)
        {
        }
      
        public DbSet<Breeds> Breeds { get; set; }
        public DbSet<Groups> Groups { get; set; }
    }
    
}
