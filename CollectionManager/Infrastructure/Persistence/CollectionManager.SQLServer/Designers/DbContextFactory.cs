using CollectionManager.SQLServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CollectionManager.SQLServer.Designers
{
    /// <summary>
    /// The <see cref="DbContext"/> factory used in design time to generate MVC Controllers using Entity Framework.
    /// </summary>=
    public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CollectionManagerDbContext>
    {
        /// <inheritdoc cref="IDesignTimeDbContextFactory{TContext}.CreateDbContext(string[])"/>
        public CollectionManagerDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CollectionManagerDbContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer("DefaultConnection");

            return new CollectionManagerDbContext(optionsBuilder.Options);
        }
    }
}