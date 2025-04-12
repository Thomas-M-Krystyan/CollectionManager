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
        internal static Operation Success()
            => new(true, LogicResources.CrudStatus_Success, string.Empty);  // Nested builder

        /// <summary>
        /// The negative outcome of the CRUD operation.
        /// </summary>
        internal static Operation Failure(string errorMessage)
            => new(false, LogicResources.CrudStatus_Failure, errorMessage);  // Nested builder

        /// <summary>
        /// Supported CRUD operations.
        /// </summary>
        internal readonly struct Operation(bool isSuccess, string status, string errorMessage)
        {
            /// <summary>
            /// The result of removing operation.
            /// </summary>
            internal CrudResponse WhenRemove(ulong id)
                => new(isSuccess, ResponseMessages.OperationRemove(isSuccess, status, id, errorMessage));

            /// <summary>
            /// The result of get all operation.
            /// </summary>
            internal CrudResponse WhenGetAll<TEntity>()
                where TEntity : class
                => new(isSuccess, ResponseMessages.OperationGetAll<TEntity>(isSuccess, status, errorMessage));
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
        internal static Operation Success(in TResult result)
            => new(true, LogicResources.CrudStatus_Success, result, string.Empty);  // Nested builder

        /// <inheritdoc cref="CrudResponse.Failure(string)"/>
        internal static Operation Failure(in TResult result, string errorMessage)
            => new(false, LogicResources.CrudStatus_Failure, result, errorMessage);  // Nested builder

        /// <inheritdoc cref="CrudResponse.Operation"/>
        internal readonly struct Operation(bool isSuccess, string status, TResult result, string errorMessage)
        {
            /// <inheritdoc cref="CrudResponse.Operation.WhenRemove(ulong)"/>
            internal CrudResponse<TResult> WhenRemove(ulong id)
                => new(isSuccess, result, ResponseMessages.OperationRemove(isSuccess, status, id, errorMessage));

            /// <inheritdoc cref="CrudResponse.Operation.WhenGetAll{TEntity}"/>
            internal CrudResponse<TResult> WhenGetAll<TEntity>()
                where TEntity : class
                => new(isSuccess, result, ResponseMessages.OperationGetAll<TEntity>(isSuccess, status, errorMessage));
        }
        #endregion

    }

    #region Response messages
    internal static class ResponseMessages
    {
        internal static string OperationRemove(bool isSuccess, string status, ulong id, string errorMessage)
        {
            return isSuccess
                ? $"{status}{string.Format(LogicResources.OperationRemove_Success, id)}"
                : $"{status}{string.Format(LogicResources.OperationRemove_Failure, id, errorMessage)}";
        }

        internal static string OperationGetAll<TEntity>(bool isSuccess, string status, string errorMessage)
            where TEntity : class
        {
            return isSuccess
                ? $"{status}{string.Format(LogicResources.OperationGetAll_Success, nameof(TEntity))}"
                : $"{status}{string.Format(LogicResources.OperationGetAll_Failure, nameof(TEntity), errorMessage)}";
        }
    }
    #endregion
}