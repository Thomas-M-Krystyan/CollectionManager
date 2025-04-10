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
        /// Indicator whether the database operation was unsuccessful.
        /// </summary>
        public bool IsFailure => !this.IsSuccess;

        /// <summary>
        /// The number of affected database rows.
        /// </summary>
        public int ChangesCount { get; } = changesCount;

        /// <summary>
        /// The database operation result message.
        /// </summary>
        public string Message { get; } = message;

        #region Predefined results
        /// <summary>
        /// The positive outcome of the database operation.
        /// </summary>
        internal static DatabaseResult Success(int changesCount, string message)
            => new(true, changesCount, message);

        /// <summary>
        /// The negative outcome of the database operation.
        /// </summary>
        internal static DatabaseResult Failure(string message)
            => new(false, 0, message);

        /// <summary>
        /// The negative outcome of the database operation.
        /// </summary>
        public static DatabaseResult Failure(Exception exception)
            => new(false, 0, exception.InnerException?.Message ?? exception.Message);
        #endregion
    }
}