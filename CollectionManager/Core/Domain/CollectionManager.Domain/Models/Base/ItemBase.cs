namespace CollectionManager.Domain.Models.Base
{
    /// <summary>
    /// An item that can be collected.
    /// </summary>
    public abstract record ItemBase
    {
        /// <summary>
        /// The unique identifier of the item.
        /// </summary>
        public required ulong Id { get; init; }

        /// <summary>
        /// The ownership status of the item (whether it was already collected or not).
        /// </summary>
        public required bool IsOwned { get; init; }

        // ---------------------------------------
        // Optional attributes of collectible item
        // ---------------------------------------

        /// <summary>
        /// The notes of the item.
        /// </summary>
        public string Notes { get; init; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemBase"/> class.
        /// </summary>
        protected ItemBase()
        {
        }
    }
}