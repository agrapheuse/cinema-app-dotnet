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

        modelBuilder.Entity<Showing>()
            .HasKey(sh => sh.Uuid);

        modelBuilder.Entity<Showing>()
            .HasOne(sh => sh.Movie)
            .WithMany(m => m.Showings)
            .HasForeignKey(sh => sh.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Like>()
            .HasKey(li => new { li.UserId, MovieId = li.ShowingId });

        modelBuilder.Entity<Like>()
            .HasOne(li => li.User)
            .WithMany(u => u.Like)
            .HasForeignKey(li => li.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Like>()
            .HasOne(li => li.Showing)
            .WithMany(m => m.Like)
            .HasForeignKey(li => li.ShowingId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<Showing>? Showings { get; set; }
    public DbSet<Movie>? Movies { get; set; }
    public DbSet<Like>? Likes { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Cinema>? Cinemas { get; set; }
}
