using CollectionManager.Domain.Enums.FileExtensions;
using CollectionManager.Logic.Extensions;
using CollectionManager.Logic.Managers.Interfaces;
using CollectionManager.Logic.Models.DTOs;
using CollectionManager.Logic.Models.Results;
using CollectionManager.Logic.Properties;
using CollectionManager.SQLServer.Context.Interfaces;
using CollectionManager.SQLServer.Entities;
using CollectionManager.SQLServer.Results;

namespace CollectionManager.Logic.Managers
{
    public sealed class ImagesCrudManager : ICrudManager<FileDto<GraphicFileExtensions>>
    {
        private readonly ICollectionManagerDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImagesCrudManager"/> class.
        /// </summary>
        public ImagesCrudManager(ICollectionManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<CrudResult> CreateAsync(FileDto<GraphicFileExtensions> dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<CrudResult> RemoveAsync(ulong id, CancellationToken cancellationToken)
        {
            try
            {
                ImageEntity? image = await this._dbContext.Images.FindAsync([id], cancellationToken);

                if (image is null)
                {
                    // TODO: Consider results builder
                    return CrudResult.Failure(string.Format(
                        LogicResources.RemoveOperation_Failure, id, LogicResources.RemoveOperation_Failure_NotFound));
                }

                _ = this._dbContext.Images.Remove(image);

                DatabaseResult databaseResult = await this._dbContext.SaveChangesAsync(cancellationToken);

                // TODO: Consider results builder
                return databaseResult.IsSuccess
                    ? CrudResult.Success(string.Format(LogicResources.RemoveOperation_Success, id))
                    : CrudResult.Failure(string.Format(LogicResources.RemoveOperation_Failure, id, databaseResult.Message));
            }
            catch (Exception exception)
            {
                return CrudResult.Failure(string.Format(LogicResources.RemoveOperation_Failure, id, exception.GetMessage()));
            }
        }

        public Task<CrudResult> UpdateAsync(ulong id, FileDto<GraphicFileExtensions> dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}