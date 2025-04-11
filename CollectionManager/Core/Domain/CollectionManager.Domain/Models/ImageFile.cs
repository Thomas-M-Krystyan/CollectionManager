using CollectionManager.Domain.Enums.FileExtensions;
using CollectionManager.Domain.Models.Base;

namespace CollectionManager.Domain.Models
{
    /// <summary>
    /// <inheritdoc cref="FileBase{TExtension}"/>
    /// It is representing graphic content.
    /// </summary>
    public record ImageFile : FileBase<Graphics>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageFile"/> class.
        /// </summary>
        public ImageFile() : base()
        {
        }
    }
}