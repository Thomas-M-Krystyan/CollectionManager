using CollectionManager.Domain.Enums;
using CollectionManager.Domain.Models.Base;

namespace CollectionManager.Domain.Models
{
    /// <summary>
    /// A file representing graphic content.
    /// </summary>
    public record ImageFile : FileBase<GraphicFileExtensions>
    {
        /// <summary>
        /// The default empty <see cref="ImageFile"/>.
        /// </summary>
        public static readonly ImageFile Empty = new()
        {
            Id = 0,
            Name = string.Empty,
            Extension = GraphicFileExtensions.Jpg,
            Bytes = [],
            Size = 0,
            CreatedAt = DateTime.MinValue
        };
    }
}