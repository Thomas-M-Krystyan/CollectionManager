﻿namespace CollectionManager.Logic.Models.Results
{
    /// <summary>
    /// Represents status of a CRUD operation.
    /// </summary>
    public readonly struct CrudResult
    {
        /// <summary>
        /// Indicator whether the CRUD operation was successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Indicator whether the CRUD operation was unsuccessful.
        /// </summary>
        public bool IsFailure => !this.IsSuccess;

        /// <summary>
        /// The status of the CRUD operation.
        /// </summary>
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
        #endregion
    }
}