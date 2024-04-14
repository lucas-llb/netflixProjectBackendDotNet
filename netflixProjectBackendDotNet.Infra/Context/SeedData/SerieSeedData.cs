using netflixProjectBackendDotNet.Domain.Entities.Serie;

namespace netflixProjectBackendDotNet.Infra.Context.SeedData;

internal static class SerieSeedData
{
    public static List<SerieEntity> SerieData = new List<SerieEntity>
    {
        new SerieEntity
        {
            Id = 1,
            Name = "Prison Break",
            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Featured = true,
            CategoryId = 1,
            ThumbnailUrl = "/serie/prisonbreak.jpg",
            CreatedAt = DateTime.UtcNow,
        },
        new SerieEntity
        {
            Id = 2,
            Name = "Breaking Bad",
            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Featured = true,
            CategoryId = 1,
            ThumbnailUrl = "/serie/breakingbad.jpg",
            CreatedAt = DateTime.UtcNow,
        },
        new SerieEntity
        {
            Id = 3,
            Name = "The Boys",
            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Featured = true,
            CategoryId = 6,
            ThumbnailUrl = "/serie/theboys.jpg",
            CreatedAt = DateTime.UtcNow,
        },
        new SerieEntity
        {
            Id = 4,
            Name = "Friends",
            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Featured = true,
            CategoryId = 3,
            ThumbnailUrl = "/serie/friends.jpg",
            CreatedAt = DateTime.UtcNow,
        },
        new SerieEntity
        {
            Id = 5,
            Name = "How I Met Your Mother",
            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Featured = true,
            CategoryId = 3,
            ThumbnailUrl = "/serie/himym.jpg",
            CreatedAt = DateTime.UtcNow,
        },
        new SerieEntity
        {
            Id = 6,
            Name = "Game of Thrones",
            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Featured = true,
            CategoryId = 5,
            ThumbnailUrl = "/serie/got.jpg",
            CreatedAt = DateTime.UtcNow,
        },
        new SerieEntity
        {
            Id = 7,
            Name = "House of the Dragon",
            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Featured = true,
            CategoryId = 5,
            ThumbnailUrl = "/serie/hotd.jpg",
            CreatedAt = DateTime.UtcNow,
        },
        new SerieEntity
        {
            Id = 8,
            Name = "The Last of Us",
            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Featured = true,
            CategoryId = 6,
            ThumbnailUrl = "/serie/tlou.jpg",
            CreatedAt = DateTime.UtcNow,
        },
        new SerieEntity
        {
            Id = 9,
            Name = "Vikings",
            Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Featured = true,
            CategoryId = 4,
            ThumbnailUrl = "/serie/vikings.jpg",
            CreatedAt = DateTime.UtcNow,
        }
    };
}
