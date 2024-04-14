using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using netflixProjectBackendDotNet.Domain.Entities.Like;

namespace netflixProjectBackendDotNet.Infra.Mappings;

public class LikeEntityMapping : IEntityTypeConfiguration<LikeEntity>
{
    private const string TableName = "Likes";
    public void Configure(EntityTypeBuilder<LikeEntity> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => new { x.UserId, x.SerieId });

        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Serie).WithMany().HasForeignKey(x => x.SerieId);

        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(x => x.UpdatedAt).IsRequired(false).ValueGeneratedOnUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
