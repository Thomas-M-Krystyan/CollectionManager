using CollectionManager.SQLServer.Context.Interfaces;
using CollectionManager.SQLServer.Entities;
using CollectionManager.SQLServer.Properties;
using CollectionManager.SQLServer.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CollectionManager.SQLServer.Context
{
    /// <inheritdoc cref="ICollectionManagerDbContext"/>
    /// <seealso cref="DbContext"/>
    public class CollectionManagerDbContext : DbContext, ICollectionManagerDbContext
    {
        #region Tables
        internal virtual DbSet<ItemEntity> Items { get; set; }

        internal virtual DbSet<ImageEntity> Images { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionManagerDbContext"/> class.
        /// </summary>
        public CollectionManagerDbContext(
            DbContextOptions<CollectionManagerDbContext> options)
            : base(options)
        {
        }

        #region Operations
        /// <inheritdoc cref="ICollectionManagerDbContext.FindAsync{TEntity}(ulong, CancellationToken)"/>
        async Task<DatabaseResult<TEntity>> ICollectionManagerDbContext.FindAsync<TEntity>(ulong id, CancellationToken cancellationToken)
            where TEntity : class
        {
            try
            {
                TEntity? result = await Set<TEntity>().FindAsync([id], cancellationToken);

                return result is not null
                    ? DatabaseResult<TEntity>.Success(result, SQLServerResources.OperationFind_Success)
                    : DatabaseResult<TEntity>.Failure(SQLServerResources.OperationFind_Failure);
            }
            catch (OperationCanceledException exception)
            {
                return DatabaseResult<TEntity>.Failure(exception.Message);
            }
        }

        /// <inheritdoc cref="ICollectionManagerDbContext.Remove{TEntity}(TEntity)"/>
        DatabaseResult ICollectionManagerDbContext.Remove<TEntity>(TEntity entity)
            where TEntity : class
        {
            EntityEntry<TEntity>? result = Set<TEntity>().Remove(entity);

            return result.State == EntityState.Deleted
                ? DatabaseResult.Success(SQLServerResources.OperationRemove_Success)
                : DatabaseResult.Failure(SQLServerResources.OperationRemove_Failure);
        }

        /// <inheritdoc cref="ICollectionManagerDbContext.SaveChangesAsync(CancellationToken)"/>
        async Task<DatabaseResult> ICollectionManagerDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                int changesCount = await base.SaveChangesAsync(cancellationToken);

                return changesCount > 0
                    ? DatabaseResult.Success(changesCount, SQLServerResources.OperationSaveChanges_Success)
                    : DatabaseResult.Failure(SQLServerResources.OperationSaveChanges_Failure);
            }
            catch (Exception exception)
            {
                return DatabaseResult.Failure(exception.Message);
            }
        }
        #endregion
    }
}