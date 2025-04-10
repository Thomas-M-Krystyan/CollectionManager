namespace CollectionManager.Logic.Models.Results
{
    /// <summary>
    /// Represents status of a CRUD operation.
    /// </summary>
    public readonly struct CrudResult
    {
        public bool IsSuccess { get; }

        public bool IsFailure => !this.IsSuccess;

        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrudResult"/> struct.
        /// </summary>
        private CrudResult(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

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
            => new(false, exception.InnerException?.Message ?? exception.Message);
        #endregion
    }
}