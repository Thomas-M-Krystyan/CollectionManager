namespace CollectionManager.Domain.Models.Base
{
    /// <summary>
    /// The file.
    /// </summary>
    public record FileBase<TExtension>
        where TExtension : Enum
    {
        /// <summary>
        /// The unique identifier of the file.
        /// </summary>
        public required int Id { get; init; }

        /// <summary>
        /// The name of the file.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// The extension of the file.
        /// </summary>
        public required TExtension Extension { get; init; }

        /// <summary>
        /// The bytes representing the file.
        /// </summary>
        public required byte[] Bytes { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileBase{TExtension}"/> class.
        /// </summary>
        protected FileBase() { }
    }
}