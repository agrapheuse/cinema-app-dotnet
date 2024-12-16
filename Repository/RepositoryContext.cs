using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CinemaConfiguration());
    }

    public DbSet<Movie>? Movies { get; set; }
    public DbSet<Like>? Likes { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Cinema>? Cinemas { get; set; }
}
