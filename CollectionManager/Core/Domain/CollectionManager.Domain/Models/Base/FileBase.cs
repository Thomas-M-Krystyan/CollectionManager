namespace CollectionManager.Domain.Models.Base
{
    /// <summary>
    /// The image of an item.
    /// </summary>
    public record FileBase<TExtension>
        where TExtension : Enum
    {
        /// <summary>
        /// The unique identifier of the file.
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// The name of the file.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// The extension of the file.
        /// </summary>
        public required TExtension Extension { get; set; }

        /// <summary>
        /// The bytes representing the file.
        /// </summary>
        public required byte[] Bytes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileBase{TExtension}"/> class.
        /// </summary>
        protected FileBase() { }
    }
}