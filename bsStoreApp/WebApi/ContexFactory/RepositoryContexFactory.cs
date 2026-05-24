using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository.EF_Core;

namespace WebApi.ContexFactory
{
    public class RepositoryContexFactory : IDesignTimeDbContextFactory<RepositoriesContex>
    {
        public RepositoriesContex CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RepositoriesContex>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                prj => prj.MigrationsAssembly("WebApi"));
                

            return new RepositoriesContex(builder.Options);
        }
    }
}
