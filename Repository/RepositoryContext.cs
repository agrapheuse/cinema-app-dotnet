using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Movie>? Movies { get; set; }
    public DbSet<Like>? Likes { get; set; }
    public DbSet<User>? Users { get; set; }
}
