namespace CollectionManager.Domain.Models.Base
{
    /// <summary>
    /// An item that can be collected.
    /// </summary>
    public record ItemBase
    {
        /// <summary>
        /// The unique identifier of the item.
        /// </summary>
        public required ulong Id { get; set; }

        /// <summary>
        /// The name of the item.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// The ownership status of the item (whether it was already collected or not).
        /// </summary>
        public required bool IsOwned { get; set; }

        // ---------------------------------------
        // Optional attributes of collectible item
        // ---------------------------------------

        /// <summary>
        /// The image representing the item.
        /// </summary>
        public ImageFile Image { get; set; } = ImageFile.Empty;

        /// <summary>
        /// The notes of the item.
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}