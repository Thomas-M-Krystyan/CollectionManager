using CollectionManager.Logic.Extensions;
using CollectionManager.Logic.Managers.Interfaces;
using CollectionManager.Logic.Models.Results;
using CollectionManager.SQLServer.Context.Interfaces;
using CollectionManager.SQLServer.Results;

namespace CollectionManager.Logic.Managers
{
    /// <inheritdoc cref="ICrudManager"/>
    public sealed class CrudManager : ICrudManager
    {
        private readonly ICollectionManagerDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrudManager"/> class.
        /// </summary>
        public CrudManager(ICollectionManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <inheritdoc cref="ICrudManager.CreateAsync{TEntity}(TEntity, CancellationToken)"/>
        public async Task<CrudResult> CreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
            where TEntity : class
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="ICrudManager.RemoveAsync(ulong, CancellationToken)"/>
        public async Task<CrudResult> RemoveAsync<TEntity>(ulong id, CancellationToken cancellationToken)
            where TEntity : class
        {
            try
            {
                // Find
                DatabaseResult<TEntity> findResult = await this._dbContext.FindAsync<TEntity>(id, cancellationToken);

                if (findResult.IsFailure)
                {
                    return CrudResult.Failure(findResult.Message).WhenRemove(id);
                }

                // Remove
                DatabaseResult removeResult = this._dbContext.Remove(findResult.Result);

                if (removeResult.IsFailure)
                {
                    return CrudResult.Failure(removeResult.Message).WhenRemove(id);
                }

                // Save
                DatabaseResult saveResult = await this._dbContext.SaveChangesAsync(cancellationToken);

                return saveResult.IsSuccess
                    ? CrudResult.Success().WhenRemove(id)
                    : CrudResult.Failure(saveResult.Message).WhenRemove(id);
            }
            catch (Exception exception)
            {
                return CrudResult.Failure(exception.GetMessage()).WhenRemove(id);
            }
        }

        /// <inheritdoc cref="ICrudManager.UpdateAsync{TEntity}(ulong, TEntity, CancellationToken)"/>
        public async Task<CrudResult> UpdateAsync<TEntity>(ulong id, TEntity entity, CancellationToken cancellationToken)
            where TEntity : class
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="ICrudManager.DisplayAllAsync{TEntity}(CancellationToken)"/>
        public async Task<CrudResult> DisplayAllAsync<TEntity>(CancellationToken cancellationToken)
            where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}