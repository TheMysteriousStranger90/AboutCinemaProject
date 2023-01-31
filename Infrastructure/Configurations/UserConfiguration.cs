using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder
            .HasMany(u => u.WatchLaterMovies)
            .WithMany(m => m.WatchLaterUsers)
            .UsingEntity(t => t.ToTable("WatchLater"));
        
        builder.HasMany(u => u.Comments).WithOne(c => c.AppUser).HasForeignKey(c => c.AppUserId);
    }
}