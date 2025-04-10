namespace CollectionManager.SQLServer.Results
{
    /// <summary>
    /// The standardized database operation result.
    /// </summary>
    public readonly struct DatabaseResult(bool isSuccess, int changesCount, string message)
    {
        /// <summary>
        /// Indicator whether the database operation was successful.
        /// </summary>
        public bool IsSuccess { get; } = isSuccess;

        /// <summary>
        /// The number of affected database rows.
        /// </summary>
        public int ChangesCount { get; } = changesCount;

        /// <summary>
        /// The database operation result message.
        /// </summary>
        public string Message { get; } = message;

        /// <summary>
        /// The operation was successful.
        /// </summary>
        internal static DatabaseResult Success(int changesCount, string message) => new(true, changesCount, message);

        /// <summary>
        /// The operation was unsuccessful.
        /// </summary>
        internal static DatabaseResult Failure(string message) => new(false, 0, message);
    }
}