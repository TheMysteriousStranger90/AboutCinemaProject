using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.PictureUrl).IsRequired();
        builder
            .HasOne(m => m.MovieGenre)
            .WithMany()
            .HasForeignKey(p => p.MovieGenreId);
        builder
            .HasOne(m => m.MovieCountry)
            .WithMany()
            .HasForeignKey(p => p.MovieCountryId);
    }
}