using CollectionManager.Logic.Properties;

namespace CollectionManager.Logic.Models.Results
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
        public static Operation Success()
        {
            ReadOnlySpan<char> status = LogicResources.CrudStatus_Success.AsSpan();

            return new Operation(true, status, string.Empty);  // Nested builder
        }

        /// <summary>
        /// The negative outcome of the CRUD operation.
        /// </summary>
        public static Operation Failure(ReadOnlySpan<char> errorMessage)
        {
            ReadOnlySpan<char> status = LogicResources.CrudStatus_Failure.AsSpan();

            return new Operation(false, status, errorMessage);  // Nested builder
        }

        /// <summary>
        /// Supported CRUD operations.
        /// </summary>
        public readonly ref struct Operation(bool isSuccess, ReadOnlySpan<char> status, ReadOnlySpan<char> errorMessage)
        {
            private readonly bool _isSuccess = isSuccess;
            private readonly ReadOnlySpan<char> _status = status;
            private readonly ReadOnlySpan<char> _errorMessage = errorMessage;

            /// <summary>
            /// The result of removing operation.
            /// </summary>
            public CrudResult WhenRemove(ulong id)
            {
                ReadOnlySpan<char> preOperation = LogicResources.ObjectId.AsSpan();
                ReadOnlySpan<char> textId = id.ToString().AsSpan();
                ReadOnlySpan<char> postOperation = this._isSuccess
                    ? LogicResources.OperationRemove_Success
                    : LogicResources.OperationRemove_Failure
                    .AsSpan();

                if (this._isSuccess)
                {
                    return new CrudResult(
                        this._isSuccess,
                        string.Concat(this._status, preOperation, textId, postOperation));
                }
                else
                {
                    Span<char> errorPostOperation = stackalloc char[postOperation.Length + this._errorMessage.Length];

                    postOperation.CopyTo(errorPostOperation);
                    this._errorMessage.CopyTo(errorPostOperation[postOperation.Length..]);

                    return new CrudResult(
                        this._isSuccess,
                        string.Concat(this._status, preOperation, textId, errorPostOperation));
                }
            }
        }
        #endregion
    }
}