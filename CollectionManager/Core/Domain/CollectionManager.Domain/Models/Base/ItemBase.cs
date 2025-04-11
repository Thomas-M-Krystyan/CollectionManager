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
        public required ulong Id { get; init; }

        /// <summary>
        /// The name of the item.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// The ownership status of the item (whether it was already collected or not).
        /// </summary>
        public required bool IsOwned { get; init; }

        /// <summary>
        /// The image representing the item.
        /// </summary>
        public required ImageFile Image { get; init; }

        // ---------------------------------------
        // Optional attributes of collectible item
        // ---------------------------------------

        /// <summary>
        /// The notes of the item.
        /// </summary>
        public string Notes { get; init; } = string.Empty;
    }
}