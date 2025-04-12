using CollectionManager.SQLServer.Responses.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace CollectionManager.SQLServer.Responses
{
    /// <inheritdoc cref="IDatabaseResponse"/>
    public readonly struct DatabaseResponse : IDatabaseResponse
    {
        /// <inheritdoc cref="IDatabaseResponse.IsSuccess"/>
        public bool IsSuccess { get; }

        /// <inheritdoc cref="IDatabaseResponse.IsFailure"/>
        public bool IsFailure => !this.IsSuccess;

        /// <inheritdoc cref="IDatabaseResponse.ChangesCount"/>
        public int ChangesCount { get; }

        /// <inheritdoc cref="IDatabaseResponse.Message"/>
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
    /// <inheritdoc cref="IDatabaseResponse"/>
    /// <para>
    ///   Containing a <typeparamref name="TResult"/> result of the database query.
    /// </para>
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public readonly struct DatabaseResponse<TResult> : IDatabaseResponse
        where TResult : class
    {
        /// <inheritdoc cref="IDatabaseResponse.IsSuccess"/>
        public bool IsSuccess { get; }

        /// <inheritdoc cref="IDatabaseResponse.IsFailure"/>
        [MemberNotNullWhen(false, nameof(Result))]
        public bool IsFailure => !this.IsSuccess;

        /// <inheritdoc cref="IDatabaseResponse.ChangesCount"/>
        public int ChangesCount { get; }

        /// <summary>
        /// The result attached to the response.
        /// </summary>
        public TResult? Result { get; }

        /// <inheritdoc cref="IDatabaseResponse.Message"/>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResponse{TResult}"/> struct.
        /// </summary>
        internal DatabaseResponse(bool isSuccess, int changesCount, TResult? result, string message)
        {
            this.IsSuccess = isSuccess;
            this.ChangesCount = changesCount;
            this.Result = result;
            this.Message = message;
        }

        #region Predefined responses
        /// <summary>
        /// The positive outcome of the database operation.
        /// </summary>
        internal static DatabaseResponse<TResult> Success(TResult result, string message)
            => new(true, 0, result, message);

        /// <summary>
        /// The positive outcome of the database operation.
        /// </summary>
        internal static DatabaseResponse<TResult> Success(int changesCount, TResult result, string message)
            => new(true, changesCount, result, message);

        /// <summary>
        /// The negative outcome of the database operation.
        /// </summary>
        internal static DatabaseResponse<TResult> Failure(string message)
            => new(false, 0, default, message);

        /// <summary>
        /// The negative outcome of the database operation.
        /// </summary>
        internal static DatabaseResponse<TResult> Failure(TResult result, string message)
            => new(false, 0, result, message);
        #endregion
    }
}