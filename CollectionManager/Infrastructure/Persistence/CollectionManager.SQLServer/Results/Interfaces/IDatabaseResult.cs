namespace CollectionManager.SQLServer.Results.Interfaces
{
    /// <summary>
    /// The standardized database operation result.
    /// </summary>
    internal interface IDatabaseResult
    {
        /// <summary>
        /// Indicator whether the database operation was successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Indicator whether the database operation was unsuccessful.
        /// </summary>
        public bool IsFailure { get; }

        /// <summary>
        /// The number of affected database rows.
        /// </summary>
        public int ChangesCount { get; }

        /// <summary>
        /// The database operation result message.
        /// </summary>
        public string Message { get; }
    }
}