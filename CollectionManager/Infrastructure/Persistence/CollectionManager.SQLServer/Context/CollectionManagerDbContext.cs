using CollectionManager.SQLServer.Context.Interfaces;
using CollectionManager.SQLServer.Entities;
using CollectionManager.SQLServer.Entities.Collectibles;
using CollectionManager.SQLServer.Properties;
using CollectionManager.SQLServer.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CollectionManager.SQLServer.Context
{
    /// <inheritdoc cref="ICollectionManagerDbContext"/>
    /// <seealso cref="DbContext"/>
    public class CollectionManagerDbContext : DbContext, ICollectionManagerDbContext
    {
        #region Tables
        public virtual DbSet<ComicEntity> Comics { get; set; }

        public virtual DbSet<ImageEntity> Images { get; set; }
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
        async Task<DatabaseResponse<TEntity>> ICollectionManagerDbContext.FindAsync<TEntity>(ulong id, CancellationToken cancellationToken)
            where TEntity : class
        {
            try
            {
                TEntity? entity = await Set<TEntity>().FindAsync([id], cancellationToken);

                return entity is not null
                    ? DatabaseResponse<TEntity>.Success(entity, SQLServerResources.OperationFind_Success)
                    : DatabaseResponse<TEntity>.Failure(SQLServerResources.OperationFind_Failure);
            }
            catch (OperationCanceledException exception)
            {
                return DatabaseResponse<TEntity>.Failure(exception.Message);
            }
        }

        /// <inheritdoc cref="ICollectionManagerDbContext.Remove{TEntity}(TEntity)"/>
        DatabaseResponse ICollectionManagerDbContext.Remove<TEntity>(TEntity entity)
            where TEntity : class
        {
            EntityEntry<TEntity>? resultEntity = Set<TEntity>().Remove(entity);

            return resultEntity.State == EntityState.Deleted
                ? DatabaseResponse.Success(SQLServerResources.OperationRemove_Success)
                : DatabaseResponse.Failure(SQLServerResources.OperationRemove_Failure);
        }

        /// <inheritdoc cref="ICollectionManagerDbContext.SaveChangesAsync(CancellationToken)"/>
        async Task<DatabaseResponse> ICollectionManagerDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                int changesCount = await base.SaveChangesAsync(cancellationToken);

                return changesCount > 0
                    ? DatabaseResponse.Success(changesCount, SQLServerResources.OperationSaveChanges_Success)
                    : DatabaseResponse.Failure(SQLServerResources.OperationSaveChanges_Failure);
            }
            catch (Exception exception)
            {
                return DatabaseResponse.Failure(exception.Message);
            }
        }
        #endregion
    }
}