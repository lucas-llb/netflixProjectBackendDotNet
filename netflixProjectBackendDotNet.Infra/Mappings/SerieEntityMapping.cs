using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using netflixProjectBackendDotNet.Domain.Entities.Serie;

namespace netflixProjectBackendDotNet.Infra.Mappings;

public class SerieEntityMapping : IEntityTypeConfiguration<SerieEntity>
{
    private const string TableName = "Series";
    public void Configure(EntityTypeBuilder<SerieEntity> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(70);
        builder.Property(x => x.Synopsis).IsRequired().HasMaxLength(250);
        builder.Property(x => x.ThumbnailUrl).IsRequired().HasMaxLength(70);
        builder.Property(x => x.Featured).IsRequired();
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(x => x.UpdatedAt).IsRequired(false).ValueGeneratedOnUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(x => x.Episodes).WithOne(x => x.Serie).HasForeignKey(x => x.SerieId);
    }
}
