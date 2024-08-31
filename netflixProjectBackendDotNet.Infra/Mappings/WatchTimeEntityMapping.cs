using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using netflixProjectBackendDotNet.Domain.Entities.WatchTime;

namespace netflixProjectBackendDotNet.Infra.Mappings;

public class WatchTimeEntityMapping : IEntityTypeConfiguration<WatchTimeEntity>
{
    private const string TableName = "WatchTimes";
    public void Configure(EntityTypeBuilder<WatchTimeEntity> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => new {x.UserId, x.EpisodeId});

        builder.HasOne(x => x.User).WithMany(x => x.WatchTimes).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Episode).WithMany().HasForeignKey(x => x.EpisodeId);

        builder.Property(x => x.SecondsLong).IsRequired();
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(x => x.UpdatedAt).IsRequired(false).ValueGeneratedOnUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
