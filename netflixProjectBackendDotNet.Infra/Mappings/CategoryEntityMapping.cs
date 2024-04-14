using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using netflixProjectBackendDotNet.Domain.Entities.Category;

namespace netflixProjectBackendDotNet.Infra.Mappings;

public class CategoryEntityMapping : IEntityTypeConfiguration<CategoryEntity>
{
    private const string TableName = "Categories";
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).UseIdentityColumn();

        builder.Property(t => t.Name).IsRequired().HasMaxLength(70);
        builder.Property(t => t.Position).IsRequired();

        builder.HasMany(x => x.Series).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
    }
}
