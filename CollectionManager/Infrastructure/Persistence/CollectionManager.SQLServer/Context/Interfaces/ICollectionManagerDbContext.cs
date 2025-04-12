using CollectionManager.SQLServer.Results;

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
        public Task<DatabaseResult<TEntity>> FindAsync<TEntity>(ulong id, CancellationToken cancellationToken)
            where TEntity : class;

        /// <summary>
        /// Removes the entity from the database.
        /// </summary>
        /// <returns>
        ///   The response from the database operation.
        /// </returns>
        public DatabaseResult Remove<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Removes the entity from the database.
        /// </summary>
        /// <returns>
        ///   The response from the database operation.
        /// </returns>
        public Task<DatabaseResult<IEnumerable<TEntity>>> DisplayAllAsync<TEntity>(CancellationToken cancellationToken)
            where TEntity : class;

        /// <summary>
        /// Saves the changes to the database.
        /// </summary>
        /// <returns>
        ///   The response from the database operation.
        /// </returns>
        public Task<DatabaseResult> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}