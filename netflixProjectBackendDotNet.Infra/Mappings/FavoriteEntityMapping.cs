using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using netflixProjectBackendDotNet.Domain.Entities.Favorite;

namespace netflixProjectBackendDotNet.Infra.Mappings;

public class FavoriteEntityMapping : IEntityTypeConfiguration<FavoriteEntity>
{
    public const string TableName = "Favorites";
    public void Configure(EntityTypeBuilder<FavoriteEntity> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => new { x.UserId, x.SerieId });

        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Serie).WithMany().HasForeignKey(x => x.SerieId);

        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(x => x.UpdatedAt).IsRequired(false).ValueGeneratedOnUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
