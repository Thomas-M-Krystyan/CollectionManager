using CollectionManager.Domain.Enums.Categories;
using CollectionManager.Domain.Enums.Genres;
using CollectionManager.Domain.Models.Base;

namespace CollectionManager.Domain.Models.Collectibles
{
    /// <summary>
    /// <inheritdoc cref="ItemBase"/>
    /// <para>
    ///   Represents a comic book or graphic novel.
    /// </para>
    /// </summary>
    public sealed record Comic : ItemBase
    {
        public required string Authors { get; init; }

        public required Literatures Genre { get; init; }

        public required Ages Age { get; init; }

        public required DateOnly Published { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Comic"/> class.
        /// </summary>
        public Comic() : base()
        {
        }
    }
}