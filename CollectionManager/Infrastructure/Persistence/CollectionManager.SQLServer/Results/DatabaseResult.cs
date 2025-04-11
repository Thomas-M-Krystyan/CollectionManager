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
    /// Containing a resulting entity <typeparamref name="TEntity"/>.
    /// </para>
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public readonly struct DatabaseResult<TEntity> : IDatabaseResult
        where TEntity : class
    {
        /// <inheritdoc cref="IDatabaseResult.IsSuccess"/>
        public bool IsSuccess { get; }

        /// <inheritdoc cref="IDatabaseResult.IsFailure"/>
        [MemberNotNullWhen(false, nameof(Entity))]
        public bool IsFailure => !this.IsSuccess;

        /// <inheritdoc cref="IDatabaseResult.ChangesCount"/>
        public int ChangesCount { get; }

        /// <summary>
        /// The entity attached to the result.
        /// </summary>
        public TEntity? Entity { get; }

        /// <inheritdoc cref="IDatabaseResult.Message"/>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResult{TEntity}"/> struct.
        /// </summary>
        internal DatabaseResult(bool isSuccess, int changesCount, TEntity? entity, string message)
        {
            this.IsSuccess = isSuccess;
            this.ChangesCount = changesCount;
            this.Entity = entity;
            this.Message = message;
        }

        #region Predefined results
        /// <summary>
        /// The positive outcome of the database operation.
        /// </summary>
        internal static DatabaseResult<TEntity> Success(TEntity entity, string message)
            => new(true, 0, entity, message);

        /// <summary>
        /// The positive outcome of the database operation.
        /// </summary>
        internal static DatabaseResult<TEntity> Success(int changesCount, TEntity entity, string message)
            => new(true, changesCount, entity, message);

        /// <summary>
        /// The negative outcome of the database operation.
        /// </summary>
        internal static DatabaseResult<TEntity> Failure(string message)
            => new(false, 0, null, message);
        #endregion
    }
}