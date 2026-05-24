using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.EF_Core.Config;


namespace Repository.EF_Core
{
    public class RepositoriesContex : DbContext
    {
        public RepositoriesContex(DbContextOptions options) :
            base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}
