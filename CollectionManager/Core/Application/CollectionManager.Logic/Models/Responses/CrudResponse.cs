using CollectionManager.Logic.Properties;

namespace CollectionManager.Logic.Models.Responses
{
    /// <summary>
    /// Represents status of a CRUD operation.
    /// </summary>
    public readonly struct CrudResponse
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
        /// Initializes a new instance of the <see cref="CrudResponse"/> struct.
        /// </summary>
        private CrudResponse(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        #region Predefined responses
        /// <summary>
        /// The positive outcome of the CRUD operation.
        /// </summary>
        public static Operation Success()
            => new(true, LogicResources.CrudStatus_Success, string.Empty);  // Nested builder

        /// <summary>
        /// The negative outcome of the CRUD operation.
        /// </summary>
        public static Operation Failure(string errorMessage)
            => new(false, LogicResources.CrudStatus_Failure, errorMessage);  // Nested builder

        /// <summary>
        /// Supported CRUD operations.
        /// </summary>
        public readonly ref struct Operation(bool isSuccess, string status, string errorMessage)
        {
            /// <summary>
            /// The result of removing operation.
            /// </summary>
            public CrudResponse WhenRemove(ulong id)
            {
                string message = isSuccess
                    ? $"{status}{string.Format(LogicResources.OperationRemove_Success, id)}"
                    : $"{status}{string.Format(LogicResources.OperationRemove_Failure, id, errorMessage)}";

                return new(isSuccess, message);
            }

            /// <summary>
            /// The result of get all operation.
            /// </summary>
            public CrudResponse WhenGetAll<TEntity>()
                where TEntity : class
            {
                string message = isSuccess
                    ? $"{status}{string.Format(LogicResources.OperationGetAll_Success, nameof(TEntity))}"
                    : $"{status}{string.Format(LogicResources.OperationGetAll_Failure, nameof(TEntity), errorMessage)}";

                return new(isSuccess, message);
            }
        }
        #endregion
    }

    /// <inheritdoc cref="CrudResponse"/>
    public readonly struct CrudResponse<TResult>
        where TResult : class
    {
        /// <inheritdoc cref="CrudResponse.IsSuccess"/>
        public bool IsSuccess { get; }

        /// <inheritdoc cref="CrudResponse.IsFailure"/>
        public bool IsFailure => !this.IsSuccess;

        /// <summary>
        /// The result attached to the response.
        /// </summary>
        public TResult? Result { get; }

        /// <inheritdoc cref="CrudResponse.Message"/>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrudResponse{TResult}"/> struct.
        /// </summary>
        private CrudResponse(bool isSuccess, in TResult? result, string message)
        {
            this.IsSuccess = isSuccess;
            this.Result = result;
            this.Message = message;
        }

        #region Predefined responses
        /// <inheritdoc cref="CrudResponse.Success()"/>
        public static Operation Success(in TResult result)
            => new(true, LogicResources.CrudStatus_Success, result, string.Empty);  // Nested builder

        /// <inheritdoc cref="CrudResponse.Failure(string)"/>
        public static Operation Failure(in TResult result, string errorMessage)
            => new(false, LogicResources.CrudStatus_Failure, result, errorMessage);  // Nested builder

        /// <inheritdoc cref="CrudResponse.Operation"/>
        public readonly struct Operation(bool isSuccess, string status, TResult result, string errorMessage)
        {
            /// <inheritdoc cref="CrudResponse.Operation.WhenRemove(ulong)"/>
            public CrudResponse<TResult> WhenRemove(ulong id)
            {
                string message = isSuccess
                    ? $"{status}{string.Format(LogicResources.OperationRemove_Success, id)}"
                    : $"{status}{string.Format(LogicResources.OperationRemove_Failure, id, errorMessage)}";

                return new(isSuccess, result, message);
            }

            /// <inheritdoc cref="CrudResponse.Operation.WhenGetAll{TEntity}"/>
            public CrudResponse<TResult> WhenGetAll<TEntity>()
                where TEntity : class
            {
                string message = isSuccess
                    ? $"{status}{string.Format(LogicResources.OperationGetAll_Success, nameof(TEntity))}"
                    : $"{status}{string.Format(LogicResources.OperationGetAll_Failure, nameof(TEntity), errorMessage)}";

                return new(isSuccess, result, message);
            }
        }
        #endregion
    }
}