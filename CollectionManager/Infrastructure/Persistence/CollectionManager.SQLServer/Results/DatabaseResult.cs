namespace CollectionManager.SQLServer.Results
{
    /// <summary>
    /// The standardized database operation result.
    /// </summary>
    public readonly struct DatabaseResult
    {
        /// <summary>
        /// Indicator whether the database operation was successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Indicator whether the database operation was unsuccessful.
        /// </summary>
        public bool IsFailure => !this.IsSuccess;

        /// <summary>
        /// The number of affected database rows.
        /// </summary>
        public int ChangesCount { get; }

        /// <summary>
        /// The database operation result message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResult"/> struct.
        /// </summary>
        private DatabaseResult(bool isSuccess, int changesCount, string message)
        {
            this.IsSuccess = isSuccess;
            this.ChangesCount = changesCount;
            this.Message = message;
        }

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
        #endregion
    }
}