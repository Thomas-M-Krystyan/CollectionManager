using CollectionManager.SQLServer.Context.Interfaces;
using CollectionManager.SQLServer.Entities;
using CollectionManager.SQLServer.Properties;
using CollectionManager.SQLServer.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CollectionManager.SQLServer.Context
{
    /// <inheritdoc cref="ICollectionManagerDbContext"/>
    /// <seealso cref="DbContext"/>
    public class CollectionManagerDbContext : DbContext, ICollectionManagerDbContext
    {
        private readonly ILogger<CollectionManagerDbContext> _logger;

        #region Tables
        public virtual DbSet<ItemEntity> Items { get; set; }

        public virtual DbSet<ImageEntity> Images { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionManagerDbContext"/> class.
        /// </summary>
        public CollectionManagerDbContext(
            DbContextOptions<CollectionManagerDbContext> options,
            ILogger<CollectionManagerDbContext> logger)
            : base(options)
        {
            this._logger = logger;
        }

        #region Operations
        /// <inheritdoc cref="DbContext.SaveChangesAsync(CancellationToken)"/>
        async Task<DatabaseResult> ICollectionManagerDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                int changesCount = await base.SaveChangesAsync(cancellationToken);

                return changesCount > 0
                    ? DatabaseResult.Success(changesCount, string.Format(SQLServerResources.DbOperationSuccessful, changesCount))
                    : DatabaseResult.Failure(SQLServerResources.DbOperationUnsuccessful);
            }
            catch (Exception exception)
            {
                string errorMessage = exception.InnerException?.Message ?? exception.Message;

                this._logger.LogError("CollectionManagerDbContext | SaveChangesAsync | Error | {message}", errorMessage);

                return DatabaseResult.Failure(errorMessage);
            }
        }
        #endregion
    }
}