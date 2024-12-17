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

        modelBuilder.Entity<UserCinema>()
            .HasKey(uc => new { uc.UserId, uc.CinemaId });

        modelBuilder.Entity<UserCinema>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCinemas)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }

    public DbSet<Movie>? Movies { get; set; }
    public DbSet<Like>? Likes { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Cinema>? Cinemas { get; set; }
}
