using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using netflixProjectBackendDotNet.Domain.Entities.User;

namespace netflixProjectBackendDotNet.Infra.Mappings;

public class UserEntityMapping : IEntityTypeConfiguration<UserEntity>
{
    private const string TableName = "Users";
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).UseIdentityColumn();

        builder.Property(t => t.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(t => t.LastName).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Email).IsRequired().HasMaxLength(70);
        builder.Property(t => t.Password).IsRequired();
        builder.Property(t => t.Phone).IsRequired().HasMaxLength(25);
        builder.Property(t => t.Birth).IsRequired();
        builder.Property(t => t.Role).IsRequired();
        builder.Property(t => t.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(t => t.UpdatedAt).IsRequired(false).ValueGeneratedOnUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
