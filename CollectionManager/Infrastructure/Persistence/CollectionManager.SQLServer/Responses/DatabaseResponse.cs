using System.Diagnostics.CodeAnalysis;

namespace CollectionManager.SQLServer.Responses
{
    /// <summary>
    /// The standardized database operation result.
    /// </summary>
    public readonly struct DatabaseResponse
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
        /// Initializes a new instance of the <see cref="DatabaseResponse"/> struct.
        /// </summary>
        internal DatabaseResponse(bool isSuccess, int changesCount, string message)
        {
            this.IsSuccess = isSuccess;
            this.ChangesCount = changesCount;
            this.Message = message;
        }

        #region Predefined responses
        /// <summary>
        /// The positive outcome of the database operation.
        /// </summary>
        internal static DatabaseResponse Success(string message)
            => new(true, 0, message);

        /// <summary>
        /// The positive outcome of the database operation.
        /// </summary>
        internal static DatabaseResponse Success(int changesCount, string message)
            => new(true, changesCount, message);

        /// <summary>
        /// The negative outcome of the database operation.
        /// </summary>
        internal static DatabaseResponse Failure(string message)
            => new(false, 0, message);
        #endregion
    }

    /// <summary>
    /// <inheritdoc cref="DatabaseResponse"/>
    /// <para>
    ///   Containing a <typeparamref name="TResult"/> result of the database query.
    /// </para>
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public readonly struct DatabaseResponse<TResult>
        where TResult : class
    {
        /// <inheritdoc cref="DatabaseResponse.IsSuccess"/>
        public bool IsSuccess { get; }

        /// <inheritdoc cref="DatabaseResponse.IsFailure"/>
        [MemberNotNullWhen(false, nameof(Result))]
        public bool IsFailure => !this.IsSuccess;

        /// <inheritdoc cref="DatabaseResponse.ChangesCount"/>
        public int ChangesCount { get; }

        /// <summary>
        /// The result attached to the database response.
        /// </summary>
        public TResult? Result { get; }

        /// <inheritdoc cref="DatabaseResponse.Message"/>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResponse{TResult}"/> struct.
        /// </summary>
        internal DatabaseResponse(bool isSuccess, int changesCount, in TResult? result, string message)
        {
            this.IsSuccess = isSuccess;
            this.ChangesCount = changesCount;
            this.Result = result;
            this.Message = message;
        }

        #region Predefined responses
        /// <inheritdoc cref="DatabaseResponse.Success(string)"/>
        internal static DatabaseResponse<TResult> Success(in TResult result, string message)
            => new(true, 0, result, message);

        /// <inheritdoc cref="DatabaseResponse.Success(int, string)"/>
        internal static DatabaseResponse<TResult> Success(int changesCount, in TResult result, string message)
            => new(true, changesCount, result, message);

        /// <inheritdoc cref="DatabaseResponse.Failure(string)"/>
        internal static DatabaseResponse<TResult> Failure(string message)
            => new(false, 0, default, message);

        /// <inheritdoc cref="DatabaseResponse.Failure(string)"/>
        internal static DatabaseResponse<TResult> Failure(in TResult result, string message)
            => new(false, 0, result, message);
        #endregion
    }
}