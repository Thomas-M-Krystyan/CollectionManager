using CollectionManager.Logic.Extensions;

namespace CollectionManager.Logic.Models.Results
{
    /// <summary>
    /// Represents status of a CRUD operation.
    /// </summary>
    public readonly struct CrudResult(bool isSuccess, string message)
    {
        /// <summary>
        /// Indicator whether the CRUD operation was successful.
        /// </summary>
        public bool IsSuccess { get; } = isSuccess;

        /// <summary>
        /// Indicator whether the CRUD operation was unsuccessful.
        /// </summary>
        public bool IsFailure => !this.IsSuccess;

        /// <summary>
        /// The status of the CRUD operation.
        /// </summary>
        public string Message { get; } = message;

        #region Predefined results
        /// <summary>
        /// The positive outcome of the CRUD operation.
        /// </summary>
        public static CrudResult Success(string message)
            => new(true, message);

        /// <summary>
        /// The negative outcome of the CRUD operation.
        /// </summary>
        public static CrudResult Failure(string errorMessage)
            => new(false, errorMessage);

        /// <summary>
        /// The negative outcome of the CRUD operation.
        /// </summary>
        public static CrudResult Failure(Exception exception)
            => new(false, exception.GetMessage());
        #endregion
    }
}