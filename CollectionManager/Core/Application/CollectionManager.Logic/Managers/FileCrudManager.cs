using CollectionManager.Domain.Enums.FileExtensions;
using CollectionManager.Logic.Managers.Interfaces;
using CollectionManager.Logic.Models.DTOs;
using CollectionManager.Logic.Models.Results;

namespace CollectionManager.Logic.Managers
{
    public sealed class FileCrudManager : ICrudManager<FileDto<GraphicFileExtensions>>
    {
        public FileCrudManager()
        {

        }

        public Task<CrudResult> CreateAsync(FileDto<GraphicFileExtensions> dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CrudResult> RemoveAsync(ulong id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CrudResult> UpdateAsync(ulong id, FileDto<GraphicFileExtensions> dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}