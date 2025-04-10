using CollectionManager.Logic.Models.Results;

namespace CollectionManager.Logic.Managers.Interfaces
{
    /// <summary>
    /// Defines supported CRUD operations.
    /// </summary>
    /// <typeparam name="TDto">The type of the DTO.</typeparam>
    public interface ICrudManager<TDto>
        where TDto : struct
    {
        /// <summary>
        /// Creates the <typeparamref name="TDto"/> object in the data store.
        /// </summary>
        /// <param name="dto">The DTO model to be used for creation.</param>
        /// <param name="cancellationToken">The cancellation token to abort the operation.</param>
        /// <returns>
        ///   The status of the CRUD operation.
        /// </returns>
        public Task<CrudResult> CreateAsync(TDto dto, CancellationToken cancellationToken);

        /// <summary>
        /// Removes the object from the data store based on the given ID.
        /// </summary>
        /// <param name="id">The ID of the object to be removed.</param>
        /// <param name="cancellationToken">The cancellation token to abort the operation.</param>
        /// <returns>
        ///   The status of the CRUD operation.
        /// </returns>
        public Task<CrudResult> RemoveAsync(ulong id, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the <typeparamref name="TDto"/> object from the data store based on the given ID.
        /// </summary>
        /// <param name="id">The ID of the object to be updated.</param>
        /// <param name="dto">The DTO model to be used for update.</param>
        /// <param name="cancellationToken">The cancellation token to abort the operation.</param>
        /// <returns>
        ///   The status of the CRUD operation.
        /// </returns>
        public Task<CrudResult> UpdateAsync(ulong id, TDto dto, CancellationToken cancellationToken);
    }
}