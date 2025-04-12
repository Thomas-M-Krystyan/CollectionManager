using CollectionManager.Logic.Extensions;
using CollectionManager.Logic.Managers.Interfaces;
using CollectionManager.Logic.Models.Responses;
using CollectionManager.SQLServer.Context.Interfaces;
using CollectionManager.SQLServer.Responses;

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
        public async Task<CrudResponse> CreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
            where TEntity : class
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="ICrudManager.RemoveAsync(ulong, CancellationToken)"/>
        public async Task<CrudResponse> RemoveAsync<TEntity>(ulong id, CancellationToken cancellationToken)
            where TEntity : class
        {
            try
            {
                // Find
                DatabaseResponse<TEntity> findResponse = await this._dbContext.FindAsync<TEntity>(id, cancellationToken);

                if (findResponse.IsFailure)
                {
                    return CrudResponse.Failure(findResponse.Message).WhenRemove(id);
                }

                // Remove
                DatabaseResponse removeResponse = this._dbContext.Remove(findResponse.Result);

                if (removeResponse.IsFailure)
                {
                    return CrudResponse.Failure(removeResponse.Message).WhenRemove(id);
                }

                // Save
                DatabaseResponse saveResponse = await this._dbContext.SaveChangesAsync(cancellationToken);

                return saveResponse.IsSuccess
                    ? CrudResponse.Success().WhenRemove(id)
                    : CrudResponse.Failure(saveResponse.Message).WhenRemove(id);
            }
            catch (Exception exception)
            {
                return CrudResponse.Failure(exception.GetMessage()).WhenRemove(id);
            }
        }

        /// <inheritdoc cref="ICrudManager.UpdateAsync{TEntity}(ulong, TEntity, CancellationToken)"/>
        public async Task<CrudResponse> UpdateAsync<TEntity>(ulong id, TEntity entity, CancellationToken cancellationToken)
            where TEntity : class
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="ICrudManager.DisplayAllAsync{TEntity}(CancellationToken)"/>
        public async Task<CrudResponse> DisplayAllAsync<TEntity>(CancellationToken cancellationToken)
            where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}