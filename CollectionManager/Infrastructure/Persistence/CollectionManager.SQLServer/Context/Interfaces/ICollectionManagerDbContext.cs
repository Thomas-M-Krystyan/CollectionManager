using CollectionManager.SQLServer.Responses;

namespace CollectionManager.SQLServer.Context.Interfaces
{
    /// <summary>
    /// The database context used for the Collection Manager application.
    /// </summary>
    public interface ICollectionManagerDbContext
    {
        #region Operations
        /// <summary>
        /// Finds an entity by its primary key.
        /// </summary>
        /// <returns>
        ///   The response from the database operation.
        /// </returns>
        public Task<DatabaseResponse<TEntity>> FindAsync<TEntity>(ulong id, CancellationToken cancellationToken)
            where TEntity : class;

        /// <summary>
        /// Removes the entity from the database.
        /// </summary>
        /// <returns>
        ///   The response from the database operation.
        /// </returns>
        public DatabaseResponse Remove<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Removes the entity from the database.
        /// </summary>
        /// <returns>
        ///   The response from the database operation.
        /// </returns>
        public Task<DatabaseResponse<IEnumerable<TEntity>>> DisplayAllAsync<TEntity>(CancellationToken cancellationToken)
            where TEntity : class;

        /// <summary>
        /// Saves the changes to the database.
        /// </summary>
        /// <returns>
        ///   The response from the database operation.
        /// </returns>
        public Task<DatabaseResponse> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}