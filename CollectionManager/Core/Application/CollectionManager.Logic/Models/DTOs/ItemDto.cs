using CollectionManager.Domain.Enums;
using CollectionManager.Domain.Enums.FileExtensions;

namespace CollectionManager.Logic.Models.DTOs
{
    public readonly struct ItemDto
    {
        public string Name { get; init; }

        public ItemCategories Category { get; init; }

        public bool IsOwned { get; init; }

        public FileDto<GraphicFileExtensions> Image { get; init; }

        public string Notes { get; init; }
    }
}