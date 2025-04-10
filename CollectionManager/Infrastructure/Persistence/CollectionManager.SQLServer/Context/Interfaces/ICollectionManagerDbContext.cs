using CollectionManager.SQLServer.Entities;
using CollectionManager.SQLServer.Results;
using Microsoft.EntityFrameworkCore;

namespace CollectionManager.SQLServer.Context.Interfaces
{
    /// <summary>
    /// The database context used for the Collection Manager application.
    /// </summary>
    public interface ICollectionManagerDbContext
    {
        #region Tables
        public DbSet<ImageEntity> Images { get; set; }

        public DbSet<ItemEntity> Items { get; set; }
        #endregion

        #region Operations
        /// <inheritdoc cref="DbContext.SaveChangesAsync(CancellationToken)"/>
        public Task<DatabaseResult> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}