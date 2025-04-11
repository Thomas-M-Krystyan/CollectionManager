using CollectionManager.Domain.Enums.Categories;
using CollectionManager.Domain.Enums.FileExtensions;
using CollectionManager.Domain.Enums.Genres;

namespace CollectionManager.Logic.Models.DTOs.Collectibles
{
    public readonly struct ComicDto
    {
        public string Name { get; init; }

        public string Authors { get; init; }

        public Literatures Genre { get; init; }

        public Ages Age { get; init; }

        public DateOnly Published { get; init; }

        public bool IsOwned { get; init; }

        public string Notes { get; init; }

        public FileDto<Graphics> Image { get; init; }
    }
}