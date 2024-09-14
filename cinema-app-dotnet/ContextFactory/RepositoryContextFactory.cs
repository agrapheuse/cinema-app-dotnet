using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace cinemaApp.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("MySqlConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'MySqlConnection' is not defined in the configuration.");
        }

        var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseMySQL(connectionString,
        b => b.MigrationsAssembly("cinemaApp"));

        return new RepositoryContext(builder.Options);
    }
}