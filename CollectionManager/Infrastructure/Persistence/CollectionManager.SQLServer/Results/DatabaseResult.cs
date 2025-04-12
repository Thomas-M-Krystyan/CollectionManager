using CollectionManager.SQLServer.Results.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace CollectionManager.SQLServer.Results
{
    /// <inheritdoc cref="IDatabaseResult"/>
    public readonly struct DatabaseResult : IDatabaseResult
    {
        /// <inheritdoc cref="IDatabaseResult.IsSuccess"/>
        public bool IsSuccess { get; }

        /// <inheritdoc cref="IDatabaseResult.IsFailure"/>
        public bool IsFailure => !this.IsSuccess;

        /// <inheritdoc cref="IDatabaseResult.ChangesCount"/>
        public int ChangesCount { get; }

        /// <inheritdoc cref="IDatabaseResult.Message"/>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResult"/> struct.
        /// </summary>
        internal DatabaseResult(bool isSuccess, int changesCount, string message)
        {
            this.IsSuccess = isSuccess;
            this.ChangesCount = changesCount;
            this.Message = message;
        }

        #region Predefined results
        /// <summary>
        /// The positive outcome of the database operation.
        /// </summary>
        internal static DatabaseResult Success(string message)
            => new(true, 0, message);

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

    /// <summary>
    /// <inheritdoc cref="IDatabaseResult"/>
    /// <para>
    ///   Containing a <typeparamref name="TResult"/> result of the database query.
    /// </para>
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public readonly struct DatabaseResult<TResult> : IDatabaseResult
        where TResult : class
    {
        /// <inheritdoc cref="IDatabaseResult.IsSuccess"/>
        public bool IsSuccess { get; }

        /// <inheritdoc cref="IDatabaseResult.IsFailure"/>
        [MemberNotNullWhen(false, nameof(Result))]
        public bool IsFailure => !this.IsSuccess;

        /// <inheritdoc cref="IDatabaseResult.ChangesCount"/>
        public int ChangesCount { get; }

        /// <summary>
        /// The result attached to the response.
        /// </summary>
        public TResult? Result { get; }

        /// <inheritdoc cref="IDatabaseResult.Message"/>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResult{TResult}"/> struct.
        /// </summary>
        internal DatabaseResult(bool isSuccess, int changesCount, TResult? result, string message)
        {
            this.IsSuccess = isSuccess;
            this.ChangesCount = changesCount;
            this.Result = result;
            this.Message = message;
        }

        #region Predefined results
        /// <summary>
        /// The positive outcome of the database operation.
        /// </summary>
        internal static DatabaseResult<TResult> Success(TResult result, string message)
            => new(true, 0, result, message);

        /// <summary>
        /// The positive outcome of the database operation.
        /// </summary>
        internal static DatabaseResult<TResult> Success(int changesCount, TResult result, string message)
            => new(true, changesCount, result, message);

        /// <summary>
        /// The negative outcome of the database operation.
        /// </summary>
        internal static DatabaseResult<TResult> Failure(string message)
            => new(false, 0, null, message);
        #endregion
    }
}