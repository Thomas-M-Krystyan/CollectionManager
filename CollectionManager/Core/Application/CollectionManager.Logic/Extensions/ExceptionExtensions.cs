namespace CollectionManager.Logic.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Exception"/> class.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Retrieves the most relevant message from the exception.
        /// </summary>
        public static string GetMessage(this Exception exception)
        {
            return exception.InnerException?.Message
                ?? exception.Message;
        }
    }
}