using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using netflixProjectBackendDotNet.Domain.Entities.Episode;

namespace netflixProjectBackendDotNet.Infra.Mappings;

public class EpisodeEntityMapping : IEntityTypeConfiguration<EpisodeEntity>
{
    private const string TableName = "Episodes";
    public void Configure(EntityTypeBuilder<EpisodeEntity> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Synopsis).IsRequired().HasMaxLength(300);
        builder.Property(x => x.Order).IsRequired();
        builder.Property(x => x.VideoUrl).IsRequired().HasMaxLength(200);
        builder.Property(x => x.ThumbnailUrl).IsRequired().HasMaxLength(200);
        builder.Property(x => x.SecondsLong).IsRequired();
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(x => x.UpdateAt).IsRequired(false).ValueGeneratedOnUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(x => x.Serie).WithMany(x => x.Episodes).HasForeignKey(x=> x.SerieId).IsRequired();
    }
}
