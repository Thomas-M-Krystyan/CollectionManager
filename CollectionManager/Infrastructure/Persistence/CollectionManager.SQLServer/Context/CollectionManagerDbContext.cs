using CollectionManager.SQLServer.Entities;
using CollectionManager.SQLServer.Properties;
using CollectionManager.SQLServer.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CollectionManager.SQLServer.Context
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionManagerDbContext"/> class.
    /// </summary>
    public class CollectionManagerDbContext(
        DbContextOptions<CollectionManagerDbContext> options,
        ILogger<CollectionManagerDbContext> logger)
        : DbContext(options)
    {
        private readonly ILogger<CollectionManagerDbContext> _logger = logger;

        #region Tables
        public virtual DbSet<ImageEntity> Images { get; set; }
        #endregion

        #region Operations
        /// <inheritdoc cref="DbContext.SaveChangesAsync(CancellationToken)"/>
        public async new Task<DbOperationResult> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                int changesCount = await base.SaveChangesAsync(cancellationToken);

                return changesCount > 0
                    ? DbOperationResult.Success(changesCount, string.Format(SQLServerResources.DbOperationSuccessful, changesCount))
                    : DbOperationResult.Failure(SQLServerResources.DbOperationUnsuccessful);
            }
            catch (Exception exception)
            {
                string errorMessage = exception.InnerException?.Message ?? exception.Message;

                this._logger.LogError("CollectionManagerDbContext | SaveChangesAsync | Error | {message}", errorMessage);

                return DbOperationResult.Failure(errorMessage);
            }
        }
        #endregion
    }
}