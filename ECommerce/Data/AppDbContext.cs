using ECommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Actor> Actors { get; set; }
    public DbSet<Actor_Movie> Actors_Movies { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ShoppingCartItem>  ShoppingCartItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Actor_Movie>()
            .HasKey(ma => new
        {
            ma.ActorId,
            ma.MovieId
        });

        modelBuilder.Entity<Actor_Movie>()
            .HasOne(m => m.Movie)
            .WithMany(ma => ma.Actors_Movies)
            .HasForeignKey(ma => ma.MovieId);

        modelBuilder.Entity<Actor_Movie>()
            .HasOne(m => m.Actor)
            .WithMany(ma => ma.Actors_Movies)
            .HasForeignKey(ma => ma.ActorId);

        base.OnModelCreating(modelBuilder);
    }
}
