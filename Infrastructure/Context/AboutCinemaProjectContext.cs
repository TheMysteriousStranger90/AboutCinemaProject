using Core.Entities;
using Infrastructure.Configurations;
using Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AboutCinemaProjectContext : IdentityDbContext<AppUser>
{
    public AboutCinemaProjectContext(){}

    public AboutCinemaProjectContext(DbContextOptions<AboutCinemaProjectContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }
        
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieGenre> MovieGenre { get; set; }
    public DbSet<MovieCountry> MovieCountry { get; set; }
    public DbSet<MovieRating> MovieRating { get; set; }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AboutCinemaProjectDb;MultipleActiveResultSets=true");
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
            
        SeedInitializer.ContextSeed(modelBuilder);
    }
}