using CollectionManager.Domain.Models.Base;

namespace CollectionManager.Domain.Models.Collectibles
{
    /// <summary>
    /// <inheritdoc cref="ItemBase"/>
    /// <para>
    ///   Represents a comic book or a graphic novel.
    /// </para>
    /// </summary>
    public sealed record Comic : ItemBase
    {
        /// <summary>
        /// The name of the series.
        /// </summary>
        public required string Series { get; init; }

        /// <summary>
        /// The title of the volume.
        /// </summary>
        public required string Title { get; init; }

        /// <summary>
        /// The number of the volume.
        /// </summary>
        public required byte Volume { get; init; }

        /// <summary>
        /// The issues included in the volume.
        /// </summary>
        public required string Issues { get; init; }

        /// <summary>
        /// The publication date.
        /// </summary>
        public required DateOnly Published { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Comic"/> class.
        /// </summary>
        public Comic() : base()
        {
        }
    }
}