using CollectionManager.Logic.Models.Results;

namespace CollectionManager.Logic.Managers.Interfaces
{
    /// <summary>
    /// Defines supported CRUD operations.
    /// </summary>
    public interface ICrudManager
    {
        /// <summary>
        /// Creates the <typeparamref name="TEntity"/> object in the data store.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="cancellationToken">The cancellation token to abort the operation.</param>
        /// <returns>
        ///   The response from the CRUD operation.
        /// </returns>
        public Task<CrudResult> CreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
            where TEntity : class;

        /// <summary>
        /// Removes the object from the data store based on the given ID.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="id">The ID of the object to be removed.</param>
        /// <param name="cancellationToken">The cancellation token to abort the operation.</param>
        /// <returns>
        ///   The response from the CRUD operation.
        /// </returns>
        public Task<CrudResult> RemoveAsync<TEntity>(ulong id, CancellationToken cancellationToken)
            where TEntity : class;

        /// <summary>
        /// Updates the <typeparamref name="TEntity"/> object from the data store based on the given ID.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="id">The ID of the object to be updated.</param>
        /// <param name="cancellationToken">The cancellation token to abort the operation.</param>
        /// <returns>
        ///   The response from the CRUD operation.
        /// </returns>
        public Task<CrudResult> UpdateAsync<TEntity>(ulong id, TEntity entity, CancellationToken cancellationToken)
            where TEntity : class;

        /// <summary>
        /// Displays all <typeparamref name="TEntity"/> objects from the data store.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="cancellationToken">The cancellation token to abort the operation.</param>
        /// <returns>
        ///   The response from the CRUD operation.
        /// </returns>
        public Task<CrudResult> DisplayAllAsync<TEntity>(CancellationToken cancellationToken)
            where TEntity : class;
    }
}