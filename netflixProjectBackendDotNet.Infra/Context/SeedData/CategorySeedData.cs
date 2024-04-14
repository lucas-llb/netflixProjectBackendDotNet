using netflixProjectBackendDotNet.Domain.Entities.Category;

namespace netflixProjectBackendDotNet.Infra.Context.SeedData;

internal static class CategorySeedData
{
    public static List<CategoryEntity> CategoryData = new List<CategoryEntity>
    {
        new CategoryEntity
        {
            Id = 1,
            Name = "Action",
            Position = 1
        },
        new CategoryEntity
        {
            Id = 2,
            Name = "Documentary",
            Position = 2
        },
        new CategoryEntity
        {
            Id = 3,
            Name = "Comedy",
            Position = 3
        },
        new CategoryEntity
        {
            Id= 4,
            Name = "Drama",
            Position = 4
        },
        new CategoryEntity
        {
            Id = 5,
            Name = "Fantasy",
            Position = 5
        },
        new CategoryEntity
        {
            Id = 6,
            Name = "Adventure",
            Position = 6,
        }
    };
}
